using PhotoHelper.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PhotoHelper.ViewModel
{
     public class SelectedItem:DependencyObject
    {

        public SelectedItem()
        {
            MessageBox.Show("Создание Selected Item");
        }


        public Folder ItemPath
        {
            get { return (Folder)GetValue(ItemPathProperty); }
            set { SetValue(ItemPathProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ItemPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemPathProperty =
            DependencyProperty.Register("ItemPath", typeof(Folder), typeof(SelectedItem), new PropertyMetadata("",ItemPath_Changed));

        private static void ItemPath_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            MessageBox.Show("Selected Item is changed");
        }
    }
}
