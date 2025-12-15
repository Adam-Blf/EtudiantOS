using EtudiantOS.Models;
using EtudiantOS.Services;

namespace EtudiantOS.ViewModels
{
    public class BudgetViewModel : ViewModelBase
    {
        private readonly BudgetService _budgetService;
        private string _vaultPath;

        private BudgetModel _budget;
        public BudgetModel Budget
        {
            get => _budget;
            set => SetProperty(ref _budget, value);
        }

        public RelayCommand SaveCommand { get; }

        public BudgetViewModel(string vaultPath)
        {
            _vaultPath = vaultPath;
            _budgetService = new BudgetService();
            Budget = _budgetService.LoadBudget(vaultPath);
            SaveCommand = new RelayCommand(Save);
        }

        private void Save(object? obj)
        {
            _budgetService.SaveBudget(_vaultPath, Budget);
            OnPropertyChanged(nameof(Budget)); // Refresh calculations
        }
    }
}
