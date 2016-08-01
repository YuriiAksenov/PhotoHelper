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
        public RenameInterfaceViewModel RenameInterfaceViewModel { get;}
        public CurrentFile CurrentFile { get; }

        public MainWindowViewModel(
            MenuViewModel menuViewModel, 
            PathControlsFromViewModel pathControlsViewModel,
            RenameInterfaceViewModel renameInterfaceViewModel)
        {
            this.MenuViewModel = menuViewModel;
            this.PathControlsFromViewModel = pathControlsViewModel;
            this.RenameInterfaceViewModel = renameInterfaceViewModel;

            MessageBox.Show("Привет");
        }
    }
}
