using PhotoHelper;
using PhotoHelper.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoHelper
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        [STAThread]
        static void Main(string[] args)
        {
            
            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel();
            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.ShowDialog();
           
        }

    }
}
