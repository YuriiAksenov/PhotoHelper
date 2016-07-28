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
            MenuViewModel menuViewModel = new MenuViewModel();
            PathControlsFromViewModel pathControlsViewModel = new PathControlsFromViewModel();
            RenameInterfaceViewModel renameInterfaceViewModel = new RenameInterfaceViewModel();

            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(menuViewModel,pathControlsViewModel,renameInterfaceViewModel);

            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.ShowDialog();
           
        }

    }
}
