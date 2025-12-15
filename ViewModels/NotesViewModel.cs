using System.Collections.ObjectModel;
using System.IO;
using EtudiantOS.Models;
using EtudiantOS.Services;

namespace EtudiantOS.ViewModels
{
    public class NotesViewModel : ViewModelBase
    {
        private readonly MarkdownService _markdownService;
        private string _vaultPath;

        public ObservableCollection<NoteModel> FileStructure { get; } = new();

        private NoteModel _selectedNote;
        public NoteModel SelectedNote
        {
            get => _selectedNote;
            set
            {
                if (SetProperty(ref _selectedNote, value))
                {
                    if (value != null && !value.IsDirectory)
                    {
                        LoadNoteContent(value.FilePath);
                    }
                }
            }
        }

        private string _currentContent;
        public string CurrentContent
        {
            get => _currentContent;
            set => SetProperty(ref _currentContent, value);
        }

        public RelayCommand SaveCommand { get; }

        public NotesViewModel(string vaultPath)
        {
            _vaultPath = vaultPath;
            _markdownService = new MarkdownService();
            SaveCommand = new RelayCommand(SaveCurrentNote);
            RefreshFiles();
        }

        public void RefreshFiles()
        {
            FileStructure.Clear();
            var files = _markdownService.GetFileStructure(_vaultPath);
            foreach (var f in files) FileStructure.Add(f);
        }

        private void LoadNoteContent(string path)
        {
            var note = _markdownService.LoadNote(path);
            if (note != null)
            {
                CurrentContent = note.Content;
                // Update SelectedNote with full data including Frontmatter if needed
                _selectedNote.Frontmatter = note.Frontmatter;
            }
        }

        private void SaveCurrentNote(object? obj)
        {
            if (SelectedNote != null)
            {
                SelectedNote.Content = CurrentContent;
                _markdownService.SaveNote(SelectedNote);
            }
        }
    }
}
