using PhotoHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoHelper.ViewModel
{
    public class CurrentFile : DependencyObject
    {

       
        public static FileInfoComponents FileInfoComponentsStatic { get; set; }

        public FileInfoComponents FileInfoComponents
        {
            get { return (FileInfoComponents)GetValue(ItemPathProperty); }
            set { SetValue(ItemPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemPathProperty =
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
            var t = d as CurrentFile;
            if(t !=null)
            {
                t.FileInfoComponents.FileId = t.FileId;
                MessageBox.Show("FileId был изменен");
            }
        }
    }
}
