using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using System.Xml.Linq;

namespace PersonalServerManager.Entities
{
    public class ServerDetailsViewModel : ViewModelBase
    {
        public ServerDetails ServerDetails { get; set; } = new ServerDetails();
        public string ServerDetailsTitle => $"{ServerDetails.Name} {ServerDetails.IP}";
        public ScriptsViewModel Scripts { get; set; } = new ScriptsViewModel();
        public StatisticsViewModel Stats { get; set; } = new StatisticsViewModel();

        private FileSystemViewModel _fileSystem;

        public FileSystemViewModel FileSystem
        {
            get => _fileSystem;
            set
            {
                _fileSystem = value;
                OnPropertyChanged(nameof(FileSystem));
            }
        }


        public ServerDetailsViewModel()
        {
            // Initialize the FileSystemViewModel
            FileSystem = new FileSystemViewModel();
        }
    }

    public class FileSystemViewModel : ViewModelBase
    {
        private FileSystemItem _rootDirectory;
        private FileSystemItem _selectedItem;

        private object _content;

        public FileSystemItem RootDirectory
        {
            get => _rootDirectory;
            set
            {
                _rootDirectory = value;
                OnPropertyChanged(nameof(RootDirectory));
            }
        }

        public FileSystemItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public object Content
        {
            get => _content;
            set
            {
                _content = value;
                OnPropertyChanged(nameof(Content));
            }
        }

        public FileSystemViewModel()
        {
            InitializeFileSystem();
        }

        private void InitializeFileSystem()
        {
            // Get the root directory
            string rootPath = @"C:\My";
            int maxDepth = 2; // Set the maximum depth
            RootDirectory = new FileSystemItem(rootPath, maxDepth);
        }       

        public ICommand ViewButtonCommand => new RelayCommand(ViewButton_Click);

        private void ViewButton_Click(object parameter)
        {
            if (SelectedItem != null)
            {
                // Determine the file type based on its extension
                string fileExtension = Path.GetExtension(SelectedItem.Name);

                // Display the content based on the file type
                switch (fileExtension.ToLower())
                {
                    case ".jpg":
                    case ".png":
                        // Display image content using an Image control
                        Image image = new Image();
                        BitmapImage bitmap = new BitmapImage(new Uri(SelectedItem.FullPath));
                        image.Source = bitmap;
                        Content = image;
                        break;
                    default:
                        // Display other file types as text
                        // Display text content using a TextBox
                        TextBox textBox = new TextBox();
                        textBox.Text = File.ReadAllText(SelectedItem.FullPath);
                        Content = textBox;
                        break;
                }
            }
        }
    }

    public class FileSystemItem
    {
        public string Name { get; }
        public string FullPath { get; }
        public ObservableCollection<FileSystemItem> Children { get; }

        public FileSystemItem(string path, int maxDepth, int currentDepth = 0)
        {
            Name = Path.GetFileName(path);
            FullPath = path;
            Children = new ObservableCollection<FileSystemItem>();

            if (currentDepth < maxDepth && Directory.Exists(path))
            {
                // Populate Children with subdirectories and files, up to the maximum depth
                foreach (string directoryPath in Directory.GetDirectories(path))
                {
                    Children.Add(new FileSystemItem(directoryPath, maxDepth, currentDepth + 1));
                }
                foreach (string filePath in Directory.GetFiles(path))
                {
                    Children.Add(new FileSystemItem(filePath, maxDepth, currentDepth + 1));
                }
            }
        }
    }
}