using PhotoHelper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using PhotoHelper.HelperMethods;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;

namespace PhotoHelper.ViewModel
{
    public  class RenameInterfaceViewModel:DependencyObject
    {
        //TODO
        //Описать свой класс где в командах будут приниматься параметры от команд https://habrahabr.ru/post/196960/  https://msdn.microsoft.com/en-us/magazine/dn237302.aspx;
       
        public ICommand AcceptChangingCommand { get; set; }
        public RenameInterfaceViewModel()
        {
            AcceptChangingCommand = new RelayCommand(this.AcceptChanging);
            FileInfoComponents = new FileInfoComponents();
        }


        public bool IsMovedAndRename
        {
            get { return (bool)GetValue(IsMovedAndRenameProperty); }
            set { SetValue(IsMovedAndRenameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsMovedAndRename.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsMovedAndRenameProperty =
            DependencyProperty.Register("IsMovedAndRename", typeof(bool), typeof(RenameInterfaceViewModel), new PropertyMetadata(false));


        /// <summary>
        /// Метод производит перемещение файла и его переименование сразу же.
        /// </summary>
        private void AcceptChanging()
        {
            try
            {
                Directory.Move(Path.Combine(PathControls.PathFrom,FileInfoComponents.FileOldName),Path.Combine(PathControls.PathTo,NewName));
                MessageNoticeUpdate = "Файл перемещён.";
                MessageBox.Show("Файл перемещён.");
                IsMovedAndRename = true;

            }
            catch(Exception e)
            {
                IsMovedAndRename = false;
                MessageBox.Show("Файл НЕ БЫЛ перемещён. Возникли проблемы. "+e.Message);
                MessageNoticeUpdate = "Файл НЕ БЫЛ перемещён. Возникли проблемы. " + e.Message;
            }
            
        }

        private bool CanAcceptChanging()
        {
            if(string.IsNullOrWhiteSpace(PathControls.PathFrom) || string.IsNullOrWhiteSpace(PathControls.PathTo))
            {
                return false;
            }
            return true;
        }



        public bool RenameInterfaceEnabled
        {
            get { return (bool)GetValue(RenameInterfaceEnabledProperty); }
            set { SetValue(RenameInterfaceEnabledProperty, value); }
        }

        // Using a DependencyProperty as the backing store for RenameInterfaceEnabled.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty RenameInterfaceEnabledProperty =
            DependencyProperty.Register("RenameInterfaceEnabled", typeof(bool), typeof(RenameInterfaceViewModel), new PropertyMetadata(false));

        public FileInfoComponents FileInfoComponents
        {
            get { return (FileInfoComponents)GetValue(CurrentFolderProperty); }
            set { SetValue(CurrentFolderProperty, value); }
        }

        public static readonly DependencyProperty CurrentFolderProperty =
            DependencyProperty.Register("FileInfoComponents", typeof(FileInfoComponents), typeof(RenameInterfaceViewModel), new PropertyMetadata(null, CurrentFolder_Changed));

        private static void CurrentFolder_Changed(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as RenameInterfaceViewModel;
            if (t != null)
            {
                t.FileId = t.FileInfoComponents.FileId;
                MessageBox.Show("FileInfoComponents был изменен");
            }
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
            var t = d as RenameInterfaceViewModel;
            if(t !=null)
            {
                bool foundname = false;
                if (!string.IsNullOrWhiteSpace(PathControls.PathFrom))
                {
                    var filenames = Directory.GetFiles(PathControls.PathFrom, PathControls.Filter, PathControls.SearchOption);
                    foreach (var filename in filenames)
                    {
                        //TODO
                        //Изменить длину на варьируемую величину
                        if (filename.Contains(t.FileId) && t.FileId.Length == filename.MaxDigitCount() && !string.IsNullOrWhiteSpace(t.FileId))
                        {
                            foundname = true;

                            t.FileInfoComponents.Parsing(filename);

                            t.NewName = null;
                            t.NewName = t.FileInfoComponents.CombineNewName();

                            break;
                        }
                    }
                }
                if(foundname)
                {
                    t.MessageNoticeFileExist = "Данный файл существует.";
                    t.MessageNoticeUpdate = "Обновлен номер файла.";

                }
                else
                {
                    t.MessageNoticeFileExist = "Данный файл НЕ существует. Проверьте или введите другое число, пожалуйста!";
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
            var t = d as RenameInterfaceViewModel;
            if(t != null)
            {
                t.FileInfoComponents.FileDescription = t.FileDescription;

                t.NewName = null;
                t.NewName = t.FileInfoComponents.CombineNewName();
                //fileDescriptionChanged.FileInfoComponents.MatchFullNewNameWithoutPathTo();
                //fileDescriptionChanged.FullNewName = fileDescriptionChanged.FileInfoComponents.FullNewNameWithoutPathTo;
                t.MessageNoticeUpdate = null;
                t.MessageNoticeUpdate = "Обновлено описание.";
                //MessageBox.Show("Обновлено описание.");
            }
        }




        public bool AdditionalChecked
        {
            get { return (bool)GetValue(AdditionalCheckedProperty); }
            set { SetValue(AdditionalCheckedProperty, value); }
        }

        // Using a DependencyProperty as the backing store for AdditionalChecked.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AdditionalCheckedProperty =
            DependencyProperty.Register("AdditionalChecked", typeof(bool), typeof(RenameInterfaceViewModel), new PropertyMetadata(false, AdditionalCheckedChanged));

        private static void AdditionalCheckedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var t = d as RenameInterfaceViewModel;
            if (t != null)
            {
                var k = (e.NewValue as bool?);
                if (k==true)
                {
                    t.FileInfoComponents.Additional = true;
                    t.NewName = t.FileInfoComponents.CombineNewName();
                    t.MessageNoticeUpdate = "Добавлен критерий дополнительно.";
                }
                else
                {
                    t.FileInfoComponents.Additional = false;
                    t.NewName = t.FileInfoComponents.CombineNewName();
                    t.MessageNoticeUpdate = "Убран критерий дополнительно.";
                }
            }

        }

        public string NewName
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
                t.MessageNoticeUpdate= "Обновлено полное имя.";
                //MessageBox.Show("Обновлено полное имя.");
            }
            
        }

        public string MessageNoticeUpdate
        {
            get { return (string)GetValue(MessageNoticeUpdateProperty); }
            set { SetValue(MessageNoticeUpdateProperty, value); }
        }

        public static readonly DependencyProperty MessageNoticeUpdateProperty =
            DependencyProperty.Register("MessageNoticeUpdate", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata(""));



        public string MessageNoticeFileExist
        {
            get { return (string)GetValue(MessageNoticeFileExistProperty); }
            set { SetValue(MessageNoticeFileExistProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MessageNotice.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MessageNoticeFileExistProperty =
            DependencyProperty.Register("MessageNoticeFileExist", typeof(string), typeof(RenameInterfaceViewModel), new PropertyMetadata(""));



    }
}
