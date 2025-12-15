using System;
using System.Collections.Generic;

namespace EtudiantOS.Models
{
    public class NoteModel
    {
        public string FilePath { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public Dictionary<string, string> Frontmatter { get; set; } = new Dictionary<string, string>();
        
        public bool IsDirectory { get; set; }
        public List<NoteModel> Children { get; set; } = new List<NoteModel>();
    }
}
