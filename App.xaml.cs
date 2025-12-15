using System.Windows;

namespace EtudiantOS
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Global exception handling
            DispatcherUnhandledException += (s, args) =>
            {
                MessageBox.Show($"Erreur inattendue : {args.Exception.Message}\n\n{args.Exception.StackTrace}", "Erreur Critique", MessageBoxButton.OK, MessageBoxImage.Error);
                args.Handled = true;
            };

            try
            {
                var mainWindow = new MainWindow();
                mainWindow.Show();
            }
            catch (Exception ex)
            {
                var error = $"Erreur au démarrage : {ex.Message}\n\n{ex.StackTrace}";
                System.IO.File.WriteAllText("crash.txt", error);
                MessageBox.Show(error, "Erreur Fatale", MessageBoxButton.OK, MessageBoxImage.Error);
                Shutdown();
            }
        }
    }
}
