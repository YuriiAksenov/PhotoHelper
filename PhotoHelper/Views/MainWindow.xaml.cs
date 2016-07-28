using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

using Microsoft.WindowsAPICodePack.Dialogs;
using PhotoHelper.ViewModel;

namespace PhotoHelper
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(MainWindowViewModel MainWindowViewModel)
        {
            DataContext = MainWindowViewModel;
            InitializeComponent();
            
        }

    }
}
