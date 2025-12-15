using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using EtudiantOS.Models;

namespace EtudiantOS.Services
{
    public class MarkdownService
    {
        public List<NoteModel> GetFileStructure(string rootPath)
        {
            if (string.IsNullOrEmpty(rootPath) || !Directory.Exists(rootPath))
                return new List<NoteModel>();

            var rootDir = new DirectoryInfo(rootPath);
            return GetDirectoryNodes(rootDir);
        }

        private List<NoteModel> GetDirectoryNodes(DirectoryInfo dir)
        {
            var nodes = new List<NoteModel>();

            foreach (var directory in dir.GetDirectories())
            {
                if (directory.Name.StartsWith(".") || directory.Name == "_System") continue; // Skip hidden/system folders

                var node = new NoteModel
                {
                    FileName = directory.Name,
                    FilePath = directory.FullName,
                    IsDirectory = true,
                    Children = GetDirectoryNodes(directory)
                };
                nodes.Add(node);
            }

            foreach (var file in dir.GetFiles("*.md"))
            {
                nodes.Add(new NoteModel
                {
                    FileName = file.Name,
                    FilePath = file.FullName,
                    IsDirectory = false
                });
            }

            return nodes;
        }

        public NoteModel LoadNote(string filePath)
        {
            if (!File.Exists(filePath)) return null;

            var content = File.ReadAllText(filePath);
            var note = new NoteModel
            {
                FilePath = filePath,
                FileName = Path.GetFileName(filePath),
                IsDirectory = false
            };

            // Simple Frontmatter Parser
            var match = Regex.Match(content, @"^---\r?\n(.*?)\r?\n---\r?\n(.*)$", RegexOptions.Singleline);
            if (match.Success)
            {
                var yaml = match.Groups[1].Value;
                note.Content = match.Groups[2].Value;
                
                foreach (var line in yaml.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    var parts = line.Split(new[] { ':' }, 2);
                    if (parts.Length == 2)
                    {
                        note.Frontmatter[parts[0].Trim()] = parts[1].Trim();
                    }
                }
            }
            else
            {
                note.Content = content;
            }

            return note;
        }

        public void SaveNote(NoteModel note)
        {
            var sb = new StringBuilder();
            if (note.Frontmatter.Count > 0)
            {
                sb.AppendLine("---");
                foreach (var kvp in note.Frontmatter)
                {
                    sb.AppendLine($"{kvp.Key}: {kvp.Value}");
                }
                sb.AppendLine("---");
            }
            sb.Append(note.Content);

            File.WriteAllText(note.FilePath, sb.ToString());
        }

        public List<string> GetTasksFromInbox(string vaultPath)
        {
            var inboxPath = Path.Combine(vaultPath, "Inbox.md");
            if (!File.Exists(inboxPath)) return new List<string>();

            var lines = File.ReadAllLines(inboxPath);
            return lines.Where(l => l.Trim().StartsWith("- [ ]")).ToList();
        }
    }
}
