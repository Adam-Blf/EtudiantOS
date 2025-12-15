using System;
using System.IO;
using System.Windows;

namespace EtudiantOS.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private string _vaultPath;
        public string VaultPath
        {
            get => _vaultPath;
            set
            {
                if (SetProperty(ref _vaultPath, value))
                {
                    InitializeViewModels();
                }
            }
        }

        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public DashboardViewModel DashboardVM { get; private set; }
        public NotesViewModel NotesVM { get; private set; }
        public BudgetViewModel BudgetVM { get; private set; }

        public RelayCommand NavigateDashboardCommand { get; }
        public RelayCommand NavigateNotesCommand { get; }
        public RelayCommand NavigateBudgetCommand { get; }
        public RelayCommand NavigateSettingsCommand { get; }

        public MainViewModel()
        {
            // Default Vault Path
            VaultPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "EtudiantOS_Vault");
            if (!Directory.Exists(VaultPath)) Directory.CreateDirectory(VaultPath);

            NavigateDashboardCommand = new RelayCommand(o => CurrentView = DashboardVM);
            NavigateNotesCommand = new RelayCommand(o => CurrentView = NotesVM);
            NavigateBudgetCommand = new RelayCommand(o => CurrentView = BudgetVM);
            NavigateSettingsCommand = new RelayCommand(o => CurrentView = "Settings"); // Simple string for now or a SettingsVM

            InitializeViewModels();
            CurrentView = DashboardVM;
        }

        private void InitializeViewModels()
        {
            DashboardVM = new DashboardViewModel(VaultPath);
            NotesVM = new NotesViewModel(VaultPath);
            BudgetVM = new BudgetViewModel(VaultPath);
            
            // If we are currently viewing one of them, refresh
            if (CurrentView is DashboardViewModel) CurrentView = DashboardVM;
        }
    }
}
