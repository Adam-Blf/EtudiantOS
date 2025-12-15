using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using EtudiantOS.Models;
using EtudiantOS.Services;

namespace EtudiantOS.ViewModels
{
    public class DashboardViewModel : ViewModelBase
    {
        private readonly CalendarService _calendarService;
        private readonly MarkdownService _markdownService;
        private string _vaultPath;

        public ObservableCollection<CoursEvent> UpcomingEvents { get; } = new();
        public ObservableCollection<string> InboxTasks { get; } = new();

        private string _quickNoteText;
        public string QuickNoteText
        {
            get => _quickNoteText;
            set => SetProperty(ref _quickNoteText, value);
        }

        public RelayCommand AddTaskCommand { get; }
        public RelayCommand AddNoteCommand { get; }

        public DashboardViewModel(string vaultPath)
        {
            _vaultPath = vaultPath;
            _calendarService = new CalendarService();
            _markdownService = new MarkdownService();

            AddTaskCommand = new RelayCommand(AddTask);
            AddNoteCommand = new RelayCommand(AddNote);

            RefreshData();
        }

        public void RefreshData()
        {
            InboxTasks.Clear();
            var tasks = _markdownService.GetTasksFromInbox(_vaultPath);
            foreach (var t in tasks) InboxTasks.Add(t);
        }

        public void LoadEvents(string filePath)
        {
            var events = _calendarService.LoadFromFile(filePath);
            UpcomingEvents.Clear();
            foreach (var e in events) UpcomingEvents.Add(e);
        }

        private void AddTask(object? obj)
        {
            // Logic to append to Inbox.md
            // Simplified for now
            MessageBox.Show("Tâche ajoutée (Simulation)");
        }

        private void AddNote(object? obj)
        {
            if (string.IsNullOrWhiteSpace(QuickNoteText)) return;
            // Logic to create a new note
            MessageBox.Show($"Note créée : {QuickNoteText}");
            QuickNoteText = "";
        }
    }
}
