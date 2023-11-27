using InputSaver.ViewModels;
using System.Windows;

namespace InputSaver
{
    public partial class App : Application
    {
        private readonly FileOperator fileOperator;

        public App()
        {
            fileOperator = new FileOperator();
        }
        
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow() { DataContext = new UserInputViewModel(fileOperator) };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
