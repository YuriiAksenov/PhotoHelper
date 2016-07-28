using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhotoHelper.ViewModel
{
    public class PathControlsViewModel : DependencyObject
    {
        /// <summary>
        /// Команда открытия диалогового окна
        /// </summary>
        public ICommand OpenFolderDialogCommand { get; set; }
        public bool IsExist { get; set; }

        public PathControlsViewModel()
        {
            OpenFolderDialogCommand = new RelayCommand(this.OpenFolderDialog);
        }

        public string FolderPath
        {
            get { return (string)GetValue(FolderPathProperty); }
            set { SetValue(FolderPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FoldetPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FolderPathProperty =
            DependencyProperty.Register("FolderPath", typeof(string), typeof(PathControlsViewModel), new PropertyMetadata("",FolderPath_Changed));

        private static void FolderPath_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as PathControlsFromViewModel;
            if (current != null)
            {
                current.IsExist = false;
                if (Directory.Exists(current.FolderPath))
                {
                    current.IsExist = true;
                }
            }
        }
        
        public void FolderPath_IsExist(string path)
        {
            if(Directory.Exists(path))
            {
                IsExist = true;
            }
            IsExist = false;
        }

        public void OpenFolderDialog()
        {
            try
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result.ToString() != "Cancel" && result.ToString() != null)
                {
                    FolderPath = dialog.FileName;
                }
            }
            catch (Exception e)
            {
                throw new Exception("Возникла ошибка в выборе папки. " + e.Message);
            }
        }

        public string CutFolderPath(string fullFolderPath = null)
            {
        return !string.IsNullOrWhiteSpace(fullFolderPath)? fullFolderPath.Substring(fullFolderPath.LastIndexOf('/'))
                :(!string.IsNullOrWhiteSpace(FolderPath) ? FolderPath.Substring(FolderPath.LastIndexOf('/')) : null);
            }

    }
}
