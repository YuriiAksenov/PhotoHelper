using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PhotoHelper.ViewModel
{
    public class PathControlsViewModel:DependencyObject
    {
        public PathControlsViewModel()
        {
            OpenFolderDialogToCommand = new RelayCommand(this.OpenFolderDialogTo);
            OpenFolderDialogFromCommand = new RelayCommand(this.OpenFolderDialogFrom);
        }

        public string PathFrom
        {
            get { return (string)GetValue(PathFromProperty); }
            set { SetValue(PathFromProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PathFrom.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathFromProperty =
            DependencyProperty.Register("PathFrom", typeof(string), typeof(PathControlsViewModel), new PropertyMetadata(""));

        private static void PathFrom_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            throw new NotImplementedException();
        }

       

        public string PathTo
        {
            get { return (string)GetValue(PathToProperty); }
            set { SetValue(PathToProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PathTo.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PathToProperty =
            DependencyProperty.Register("PathTo", typeof(string), typeof(PathControlsViewModel), new PropertyMetadata(""));
        


        public ICommand OpenFolderDialogFromCommand { get; set; }
        public ICommand OpenFolderDialogToCommand { get; set; }
       
       

        public void  OpenFolderDialogFrom()
        {

            try
            {
                var dialog = new CommonOpenFileDialog();

                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result.ToString() != "Cancel")
                {
                    PathFrom = dialog.FileName;
                }
            }
            catch
            {
                throw new Exception("Не смог выбрать папку откуда.");
            }
        }
        public void OpenFolderDialogTo()
        {
            try
            {
                var dialog = new CommonOpenFileDialog();

                dialog.IsFolderPicker = true;
                CommonFileDialogResult result = dialog.ShowDialog();
                if (result.ToString() != "Cancel")
                {
                    PathTo = dialog.FileName;
                }
            }
            catch
            {
                throw new Exception("Не смог выбрать папку куда.");
            }
        }

    }
}
