using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PhotoHelper.ViewModel
{
    public class PathControlsViewModel: ViewModelBase
    { 
        public ICommand OpenFolderDialogFromCommand { get; set; }
        public string PathFrom { get; set; }

        internal PathControlsViewModel()
        {
            OpenFolderDialogFromCommand = new RelayCommand(this.OpenFolderDialogFrom);
        }

        public void  OpenFolderDialogFrom()
        {
            try
            {
                var dialog = new CommonOpenFileDialog();

                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result.ToString() != "Cancel")
                {
                    PathFrom = dialog.FileName;
                }
            }
            catch
            {
                throw new Exception("Не смог выбрать папку.");
            }
        }

    }
}
