using PersonalServerManager.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace PersonalServerManager
{
    /// <summary>
    /// Interaction logic for AddProjectPopup.xaml
    /// </summary>
    public partial class AddProjectPopup : Window
    {
        private readonly ProjectsViewModel _projectsViewModel;

        private string _selectedFilePath;

        public string SelectedFilePath
        {
            get => _selectedFilePath;
            set
            {
                _selectedFilePath = value;
                //OnPropertyChanged(nameof(SelectedFilePath));
            }
        }

        public ICommand SelectFileCommand { get; }


        public AddProjectPopup(ProjectsViewModel projectsViewMode)
        {
            InitializeComponent();

            _projectsViewModel = projectsViewMode;
            SelectFileCommand = new RelayCommand(SelectFile);
        }


        public void SelectFile(object parameter)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "All files (*.*)|*.*"; // Filter to allow selection of all file types
            bool? result = dialog.ShowDialog();
            if (result == true)
            {
                SelectedFilePath = dialog.FileName;
            }
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string path = PathTextBox.Text;
            string notes = NotesTextBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                _projectsViewModel.AddProject(new ProjectDetails
                {
                    Name = name,
                    Path = path,
                    Notes = notes
                });

                MessageBox.Show("Project added successfully.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
