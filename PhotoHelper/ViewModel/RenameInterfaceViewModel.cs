using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotoHelper.ViewModel
{
    public  class RenameInterfaceViewModel
    {
        private PathControlsFromViewModel _pathControlsFromViewModel;

        public RenameInterfaceViewModel(PathControlsFromViewModel pathControlsFromViewModel)
        {
            this._pathControlsFromViewModel = pathControlsFromViewModel;
        }
    }
}
