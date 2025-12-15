using System.Windows;
using EtudiantOS.ViewModels;

namespace EtudiantOS
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
