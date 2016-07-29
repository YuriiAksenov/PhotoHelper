using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using PhotoHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PhotoHelper.ViewModel
{
    public class PathControlsFromViewModel:DependencyObject
    {

        public ICommand OpenFolderDialogCommand { get; set; }
       
        public bool IsExist { get; set; }
        public CurrentFile CurrentFile { get; set; }
        
        public PathControlsFromViewModel(CurrentFile currentFile)
        {
            GetFiles();
            OpenFolderDialogCommand = new RelayCommand(this.OpenFolderDialog);
            CurrentFile = currentFile;
        }


        public FileInfoComponents SelectedFile
        {
            get { return (Model.FileInfoComponents)GetValue(SelectedFileProperty); }
            set { SetValue(SelectedFileProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedFile.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedFileProperty =
            DependencyProperty.Register("SelectedFile", typeof(Model.FileInfoComponents), typeof(PathControlsFromViewModel), new PropertyMetadata(null, FileInfoComponents_Changed));

        private static void FileInfoComponents_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as PathControlsFromViewModel;
            if (t != null &&  t.SelectedFile!=null)
            {
                t.CurrentFile.CurrentFileBuffer= t.SelectedFile;
                //SelectedItem.ItemPath = Path.Combine(t.SelectedFile.oldPath,t.SelectedFile.fileName);
                //MessageBox.Show(SelectedItem.ItemPath);

                MessageBox.Show(string.IsNullOrWhiteSpace(t.SelectedFile.PathFrom) ? "Не выбран" : t.SelectedFile.PathFrom + "  " + (string.IsNullOrWhiteSpace(t.SelectedFile.FileName)? "Не выбран" : t.SelectedFile.FileName));
            }
        }

       
        public string FolderPath
        {
            get { return (string)GetValue(FolderPathProperty); }
            set { SetValue(FolderPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FoldetPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FolderPathProperty =
            DependencyProperty.Register("FolderPath", typeof(string), typeof(PathControlsFromViewModel), new PropertyMetadata("", FolderPath_Changed));

        private static void FolderPath_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var current = d as PathControlsFromViewModel;
            if (current != null)
            {
                current.IsExist = false;
                if (Directory.Exists(current.FolderPath))
                {
                    current.IsExist = true;
                    current.Items = null;
                    current.Items = CollectionViewSource.GetDefaultView(Model.FileInfoComponents.GetFilesInfo(current.FolderPath));
                }
            }
        }

        public void GetFiles()
        {
            if (Directory.Exists(FolderPath))
            {
                Items = CollectionViewSource.GetDefaultView(Model.FileInfoComponents.GetFilesInfo(FolderPath));
            }
        }

        public void FolderPath_IsExist(string path)
        {
            if (Directory.Exists(path))
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
            return !string.IsNullOrWhiteSpace(fullFolderPath) ? fullFolderPath.Substring(fullFolderPath.LastIndexOf('/'))
                    : (!string.IsNullOrWhiteSpace(FolderPath) ? FolderPath.Substring(FolderPath.LastIndexOf('/')) : null);
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(PathControlsFromViewModel), new PropertyMetadata(null));

        




    }
}
