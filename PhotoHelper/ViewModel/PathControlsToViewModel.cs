using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using PhotoHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace PhotoHelper.ViewModel
{
    public class PathControlsToViewModel:DependencyObject
    {
        public RenameInterfaceViewModel RenameInterfaceViewModel { get; set; }

        public ICommand OpenFolderDialogCommand { get; set; }

        public PathControlsToViewModel(RenameInterfaceViewModel renameInterfaceViewModel)
        {
            RenameInterfaceViewModel = renameInterfaceViewModel;
            OpenFolderDialogCommand = new RelayCommand(this.OpenFolderDialog);
        }

        public string FolderPath
        {
            get { return (string)GetValue(FolderPathProperty); }
            set { SetValue(FolderPathProperty, value); }
        }

        public static readonly DependencyProperty FolderPathProperty =
            DependencyProperty.Register("FolderPath", typeof(string), typeof(PathControlsToViewModel), new PropertyMetadata("", FolderPath_Changed));

        private static void FolderPath_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as PathControlsToViewModel;
            if (t != null)
            {
                if (Directory.Exists(t.FolderPath))
                {
                    PathControls.PathTo = t.FolderPath;
                    t.Items = null;
                    t.Items = CollectionViewSource.GetDefaultView(ForCollectionItems.GetItems(PathControls.PathTo, PathControls.Filter, SearchOption.TopDirectoryOnly));


                    t.MessageNoticeFolderExist = "Выбранный путь сещуствует.";
                    t.RenameInterfaceViewModel.MessageNoticeUpdate = "Выбран новый путь папки источника.";

                }
                else { t.MessageNoticeFolderExist = "Выбранный путь НЕ сещуствует."; }
            }
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


        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(PathControlsToViewModel), new PropertyMetadata(null));


        public string MessageNoticeFolderExist
        {
            get { return (string)GetValue(MessageNoticeFolderExistProperty); }
            set { SetValue(MessageNoticeFolderExistProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageNoticeFolderExist.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageNoticeFolderExistProperty =
            DependencyProperty.Register("MessageNoticeFolderExist", typeof(string), typeof(PathControlsToViewModel), new PropertyMetadata("", Changed));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           // MessageBox.Show("Изменился путь");
        }
    }
}
