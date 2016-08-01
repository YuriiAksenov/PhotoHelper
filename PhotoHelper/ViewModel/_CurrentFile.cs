using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using PhotoHelper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhotoHelper.ViewModel
{
    public class CurrentFile : DependencyObject
    {
        //TODO
        //Описать свой класс где в командах будут приниматься параметры от команд https://habrahabr.ru/post/196960/  https://msdn.microsoft.com/en-us/magazine/dn237302.aspx

        /*public static FileInfoComponents FileInfoComponentsStatic{ get; set; }

        public RelayCommand OpenFolderDialogCommandFrom{ get; set; }
        public RelayCommand OpenFolderDialogCommandTo { get; set; }
        

        public CurrentFile()
        {
            OpenFolderDialogCommandFrom = new RelayCommand(this.OpenFolderDialogFrom);
            OpenFolderDialogCommandTo = new RelayCommand(this.OpenFolderDialogTo);
        }


        public FileInfoComponents FileInfoComponents
        {
            get { return (FileInfoComponents)GetValue(FileInfoComponentsProperty); }
            set { SetValue(FileInfoComponentsProperty, value); }
        }

        public static readonly DependencyProperty FileInfoComponentsProperty =
            DependencyProperty.Register("ItemPath", typeof(FileInfoComponents), typeof(CurrentFile), new PropertyMetadata(null, FileInfoComponentsChanged));

        private static void FileInfoComponentsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            
            var t = d as CurrentFile;
            if (t != null)
            {
                FileInfoComponentsStatic = t.FileInfoComponents;
                t.FileId = t.FileInfoComponents.FileId;
                MessageBox.Show("FileInfoComponents был изменен");
            }
        }





        public string FileId
        {
            get { return (string)GetValue(FileIdProperty); }
            set { SetValue(FileIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileIdProperty =
            DependencyProperty.Register("FileId", typeof(string), typeof(CurrentFile), new PropertyMetadata("",FileIdChanged));

        private static void FileIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileIdChanged = d as RenameInterfaceViewModel;
            if (fileIdChanged != null)
            {
                var filenames = Directory.GetFiles(fileIdChanged.CurrentFile.FileInfoComponents.PathFrom, "*.*", SearchOption.TopDirectoryOnly);
                bool foundname = false;
                foreach (var filename in filenames)
                {
                    if (filename.Contains(fileIdChanged.FileId) && fileIdChanged.FileId.Length >= 4 && fileIdChanged.FileId.Length <= 5)
                    {
                        foundname = true;
                        fileIdChanged.FileInfoComponents.Parsing(filename);
                        fileIdChanged.FullNewName = fileIdChanged.CurrentFile.FileInfoComponents.MatchFullNewNameWithoutPathTo();
                        fileIdChanged.CurrentFile.FileInfoComponents.MatchFullNewNameWithoutPathTo();
                        fileIdChanged.FullNewName = null;
                        fileIdChanged.FullNewName = fileIdChanged.CurrentFile.FileInfoComponents.FullNewNameWithoutPathTo;

                        break;
                    }
                }
                if (foundname)
                {
                    fileIdChanged.MessageNotice = "Данный файл существует.";

                }
                else
                {
                    fileIdChanged.MessageNotice = "Данный файл НЕ существует. Проверьте или введите другое число, пожалуйста!";
                }
            };



        #region Ненужные методы открытия диалогов, так как пока всё связано и невозможно и отделить в отдельный класс
        private void OpenFolderDialogFrom()
        {
            try
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result.ToString() != "Cancel" && result.ToString() != null)
                {
                    //FolderPath = dialog.FileName;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Возникла ошибка в выборе папки Откуда. " + e.Message);
            }
        }
        private void OpenFolderDialogTo()
        {
            try
            {
                var dialog = new CommonOpenFileDialog();
                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result.ToString() != "Cancel" && result.ToString() != null)
                {
                    //FolderPath = dialog.FileName;
                }

            }
            catch (Exception e)
            {
                throw new Exception("Возникла ошибка в выборе папки Куда. " + e.Message);
            }
        }

        #endregion
        */
    }
}
