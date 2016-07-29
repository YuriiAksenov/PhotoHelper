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

        public CurrentFile()
        {
            MessageBox.Show("Создание Selected Item");
        }
        public static FileInfoComponents CurrentFileBufferStatic { get;set;}

        public FileInfoComponents CurrentFileBuffer
        {
            get { return (FileInfoComponents)GetValue(ItemPathProperty); }
            set { SetValue(ItemPathProperty, value); }
        }
 
        // Using a DependencyProperty as the backing store for ItemPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemPathProperty =
            DependencyProperty.Register("ItemPath", typeof(FileInfoComponents), typeof(CurrentFile), new PropertyMetadata(null, CurrenttFileBufferChanged));

        private static void CurrenttFileBufferChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("Selected Item is changed");
            var t = d as CurrentFile;
            if (t != null)
            {
                CurrentFileBufferStatic = (d as CurrentFile).CurrentFileBuffer;
            }
        }
    }
}
