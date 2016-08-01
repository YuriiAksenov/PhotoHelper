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
            CurrentFile currentFile = new CurrentFile();

            MenuViewModel menuViewModel = new MenuViewModel();
            RenameInterfaceViewModel renameInterfaceViewModel = new RenameInterfaceViewModel();
            PathControlsFromViewModel pathControlsFromViewModel = new PathControlsFromViewModel(renameInterfaceViewModel);
            PathControlsToViewModel pathControlsToViewModel = new PathControlsToViewModel(renameInterfaceViewModel);


            MainWindowViewModel mainWindowViewModel = new MainWindowViewModel(menuViewModel,pathControlsFromViewModel, pathControlsToViewModel, renameInterfaceViewModel);

            MainWindow mainWindow = new MainWindow(mainWindowViewModel);
            mainWindow.ShowDialog();
           
        }

    }
}
