using System;
using System.Windows;

namespace EtudiantOS
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            try
            {
                var app = new App();
                app.InitializeComponent(); // This parses App.xaml
                app.Run();
            }
            catch (Exception ex)
            {
                var error = $"CRASH AU DEMARRAGE (Main): {ex.Message}\n\n{ex.StackTrace}";
                if (ex.InnerException != null)
                {
                    error += $"\n\nInner Exception: {ex.InnerException.Message}\n{ex.InnerException.StackTrace}";
                }
                System.IO.File.WriteAllText("crash.txt", error);
                MessageBox.Show(error, "Erreur Fatale Main", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
