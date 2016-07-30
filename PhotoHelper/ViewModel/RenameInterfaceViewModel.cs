using PhotoHelper.Model;
using System;
using System.Collections.Generic;
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

        // Using a DependencyProperty as the backing store for FileId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileIdProperty =
            DependencyProperty.Register("FileId", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata(""));



        public string FileDescription
        {
            get { return (string)GetValue(FileDescriptionProperty); }
            set { SetValue(FileDescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileDescriptionProperty =
            DependencyProperty.Register("FileDescription", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata("",FileDescriptionChanged));

        private static void FileDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var fileDescriptionChanged = d as RenameInterfaceViewModel;
            if(fileDescriptionChanged != null)
            {
                fileDescriptionChanged.CurrentFile.FileInfoComponents.FileDescription = fileDescriptionChanged.FileDescription;
            }
        }

        public FileInfoComponents FileInfoComponents
        {
            get { return (FileInfoComponents)GetValue(CurrentFolderProperty); }
            set { SetValue(CurrentFolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentFolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentFolderProperty =
            DependencyProperty.Register("CurrentFolder", typeof(FileInfoComponents), typeof(RenameInterfaceViewModel), new PropertyMetadata(null,CurrentFolder_Changed));

        private static void CurrentFolder_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as RenameInterfaceViewModel;
            if(t!=null)
            MessageBox.Show(t.FileInfoComponents.FileName);
        }

        
    }
}
