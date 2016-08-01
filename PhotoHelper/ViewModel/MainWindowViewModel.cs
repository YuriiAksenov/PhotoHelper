using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoHelper.ViewModel
{
    public class MainWindowViewModel
    {
        public MenuViewModel MenuViewModel { get;}
        public PathControlsFromViewModel PathControlsFromViewModel { get;}
        public PathControlsToViewModel PathControlsToViewModel { get; }
        public RenameInterfaceViewModel RenameInterfaceViewModel { get;}
        public CurrentFile CurrentFile { get; }

        public MainWindowViewModel(
            MenuViewModel menuViewModel, 
            PathControlsFromViewModel pathControlsViewModel,
            PathControlsToViewModel pathControlsToViewModel,
            RenameInterfaceViewModel renameInterfaceViewModel)
        {
            this.MenuViewModel = menuViewModel;
            this.PathControlsFromViewModel = pathControlsViewModel;
            this.PathControlsToViewModel = pathControlsToViewModel;
            this.RenameInterfaceViewModel = renameInterfaceViewModel;

            MessageBox.Show("Привет");
        }
    }
}
