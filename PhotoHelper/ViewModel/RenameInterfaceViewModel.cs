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
        public SelectedItem SelectedItem { get;}

        public string MyProperty
        {
            get { return (string)GetValue(MyPropertyProperty); }
            set { SetValue(MyPropertyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPropertyProperty =
            DependencyProperty.Register("MyProperty", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata("",Changed));

        private static void Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as RenameInterfaceViewModel;
            if (t != null)
                MessageBox.Show(t.MyProperty);
        }

        public Folder CurrentFolder
        {
            get { return (Folder)GetValue(CurrentFolderProperty); }
            set { SetValue(CurrentFolderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CurrentFolder.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CurrentFolderProperty =
            DependencyProperty.Register("CurrentFolder", typeof(Folder), typeof(RenameInterfaceViewModel), new PropertyMetadata(null,CurrentFolder_Changed));

        private static void CurrentFolder_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as RenameInterfaceViewModel;
            if(t!=null)
            MessageBox.Show(t.CurrentFolder.fileName);
        }

        public RenameInterfaceViewModel(SelectedItem SelectedItem)
        {
            this.SelectedItem = SelectedItem;
            MyProperty = "How";
            
            
            
        }
        
    }
}
