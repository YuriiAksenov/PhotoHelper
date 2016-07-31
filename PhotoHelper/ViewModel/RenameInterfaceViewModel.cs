using PhotoHelper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoHelper.ViewModel
{
    public  class RenameInterfaceViewModel:DependencyObject
    {
        public CurrentFile CurrentFile { get; set; }

        public RenameInterfaceViewModel(CurrentFile currentFile)
        {
            this.CurrentFile = currentFile;    
        }
        
        public string FileId
        {
            get { return (string)GetValue(FileIdProperty); }
            set { SetValue(FileIdProperty, value); }
        }

        public static readonly DependencyProperty FileIdProperty =
            DependencyProperty.Register("FileId", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata("",FileIdChanged));

        private static void FileIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileIdChanged = d as RenameInterfaceViewModel;
            if(fileIdChanged !=null)
            {
                var filenames = Directory.GetFiles(fileIdChanged.CurrentFile.FileInfoComponents.PathFrom, "*.*", SearchOption.TopDirectoryOnly);
                bool foundname = false;
                foreach(var filename in filenames)
                {
                    if(filename.Contains(fileIdChanged.FileId) && fileIdChanged.FileId.Length>=4 && fileIdChanged.FileId.Length<=5)
                    {
                        foundname = true;
                        fileIdChanged.CurrentFile.FileInfoComponents.Parsing(filename);
                        fileIdChanged.FullNewName = fileIdChanged.CurrentFile.FileInfoComponents.MatchFullNewNameWithoutPathTo();
                        fileIdChanged.CurrentFile.FileInfoComponents.MatchFullNewNameWithoutPathTo();
                        fileIdChanged.FullNewName = null;
                        fileIdChanged.FullNewName = fileIdChanged.CurrentFile.FileInfoComponents.FullNewNameWithoutPathTo;

                        break;
                    }
                }
                if(foundname)
                {
                    fileIdChanged.MessageNotice = "Данный файл существует.";

                }
                else
                {
                    fileIdChanged.MessageNotice = "Данный файл НЕ существует. Проверьте или введите другое число, пожалуйста!";
                }
            }
        }

        public string FileDescription
        {
            get { return (string)GetValue(FileDescriptionProperty); }
            set { SetValue(FileDescriptionProperty, value); }
        }

        public static readonly DependencyProperty FileDescriptionProperty =
            DependencyProperty.Register("FileDescription", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata("",FileDescriptionChanged));

        private static void FileDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileDescriptionChanged = d as RenameInterfaceViewModel;
            if(fileDescriptionChanged != null)
            {
                fileDescriptionChanged.CurrentFile.FileInfoComponents.FileDescription = fileDescriptionChanged.FileDescription;

                fileDescriptionChanged.FullNewName = null;
                fileDescriptionChanged.CurrentFile.FileInfoComponents.MatchFullNewNameWithoutPathTo();
                fileDescriptionChanged.FullNewName = fileDescriptionChanged.CurrentFile.FileInfoComponents.FullNewNameWithoutPathTo;
                fileDescriptionChanged.MessageNotice = null;
                fileDescriptionChanged.MessageNotice = "Обновлено описание.";
                MessageBox.Show("Обновлено описание.");
            }
        }

        public FileInfoComponents FileInfoComponents
        {
            get { return (FileInfoComponents)GetValue(CurrentFolderProperty); }
            set { SetValue(CurrentFolderProperty, value); }
        }

        public static readonly DependencyProperty CurrentFolderProperty =
            DependencyProperty.Register("FileInfoComponents", typeof(FileInfoComponents), typeof(RenameInterfaceViewModel), new PropertyMetadata(null,CurrentFolder_Changed));

        private static void CurrentFolder_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as RenameInterfaceViewModel;
            if(t!=null)
            MessageBox.Show(t.FileInfoComponents.FileName);
        }



        public string FullNewName
        {
            get { return (string)GetValue(FullNewNameProperty); }
            set { SetValue(FullNewNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FullNewName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FullNewNameProperty =
            DependencyProperty.Register("FullNewName", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata("",FIleNewNameChanged));

        private static void FIleNewNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as RenameInterfaceViewModel;
            if(t!=null)
            {
                t.MessageNotice= "Обновлено полное имя.";
                MessageBox.Show("Обновлено полное имя.");
            }
            
        }

        public string MessageNotice
        {
            get { return (string)GetValue(MessageNoticeProperty); }
            set { SetValue(MessageNoticeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageNotice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageNoticeProperty =
            DependencyProperty.Register("MessageNotice", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata(""));



    }
}
