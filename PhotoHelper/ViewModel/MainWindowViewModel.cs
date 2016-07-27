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
        public PathControlsViewModel PathControlsViewModel { get;}
        public RenameInterfaceViewModel RenameInterfaceViewModel { get;}

        public MainWindowViewModel(
            MenuViewModel menuViewModel, 
            PathControlsViewModel pathControlsViewModel,
            RenameInterfaceViewModel renameInterfaceViewModel)
        {
            this.MenuViewModel = menuViewModel;
            this.PathControlsViewModel = pathControlsViewModel;
            this.RenameInterfaceViewModel = renameInterfaceViewModel;

            MessageBox.Show("Привет");
        }
    }
}
