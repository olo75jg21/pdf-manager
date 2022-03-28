using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using Microsoft.WindowsAPICodePack.Dialogs;


namespace pdf_manager
{
    internal class TreeComponents
    {
        private static string _currentDirectory;
        public static string CurrentDirectory { get { return _currentDirectory; } }

        public static string OpenDirectoryDialog()
        {
            var dlg = new CommonOpenFileDialog();
            dlg.Title = "Wybierz katalog do dodania";
            dlg.IsFolderPicker = true;
            dlg.InitialDirectory = _currentDirectory;

            dlg.AddToMostRecentlyUsedList = false;
            dlg.AllowNonFileSystemItems = false;

            dlg.EnsureFileExists = true;
            dlg.EnsurePathExists = true;
            dlg.EnsureReadOnly = false;
            dlg.EnsureValidNames = true;
            dlg.Multiselect = false;
            dlg.ShowPlacesList = true;

            if (dlg.ShowDialog() == CommonFileDialogResult.Ok)
            {
                _currentDirectory = dlg.FileName;
            }

            return _currentDirectory;
        }
    }

    interface ITreeViewItemViewModel : INotifyPropertyChanged
    {
        bool IsExpanded { get; set; }
        bool IsSelected { get; set; }
    }

    public class ItDirectory : ITreeViewItemViewModel
    {
        private bool _isExpanded;
        private bool _isSelected;
        public event PropertyChangedEventHandler PropertyChanged;

        private static readonly List<string> allowedExtensions = new List<string> { ".pdf" };

        public ItDirectory(string path)
        {
            DirectoryPath = path;

            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            foreach (FileInfo file in directoryInfo.GetFiles())
                if (allowedExtensions.Contains(file.Extension))
                    Files.Add(new ItFile(file.FullName));

            foreach(DirectoryInfo directory in directoryInfo.GetDirectories())
                SubFolders.Add(new ItDirectory(directory.FullName));
        }

        public ObservableCollection<ItFile> Files { get; set; } = new ObservableCollection<ItFile>();
        public ObservableCollection<ItDirectory> SubFolders { get; set; } = new ObservableCollection<ItDirectory>();

        public IEnumerable Items { get { return SubFolders?.Cast<Object>().Concat(Files); } }
        
        public String DirectoryPath { get; set; }
        public String Name { get { return Path.GetFileName(Path.GetFileName(DirectoryPath)); } }

        public override string ToString() { return Name; }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }
    }

    public class ItFile : ITreeViewItemViewModel
    {
        private bool _isExpanded;
        private bool _isSelected;
        public event PropertyChangedEventHandler PropertyChanged;
        public ItFile(string path)
        {
            FilePath = path;
        }

        public String FilePath { get; set; }
        public String Name { get { return Path.GetFileName(FilePath); } }
    
        public override string ToString() { return Name; }

        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set
            {
                if (value != _isExpanded)
                {
                    _isExpanded = value;
                    this.OnPropertyChanged("IsExpanded");
                }
            }
        }
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (value != _isSelected)
                {
                    _isSelected = value;
                    this.OnPropertyChanged("IsSelected");
                }
            }
        }
    }
}
