using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
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
    public class PathControlsFromViewModel:PathControlBase
    {
        

        public ICommand UpdateCommand { get; set; }
        //<summary
        public PathControlsFromViewModel()
        {
            UpdateCommand = new RelayCommand(this.Update);
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        public ICollectionView Items
        {
            get { return (ICollectionView)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Items.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register("Items", typeof(ICollectionView), typeof(PathControlsFromViewModel), new PropertyMetadata(null));

        public void GetFiles()
        {
            if(Directory.Exists(FolderPath))
            {
                Items = CollectionViewSource.GetDefaultView(Directory.GetFiles(FolderPath));
            }
        }
    }
}
