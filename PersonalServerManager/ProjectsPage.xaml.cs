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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PersonalServerManager
{
    /// <summary>
    /// Interaction logic for ProjectsPage.xaml
    /// </summary>
    public partial class ProjectsPage : UserControl
    {
        private readonly AddProjectPopup _addProjectPopup;
        private readonly ProjectsViewModel _projectsViewModel;
        public ProjectsPage(AddProjectPopup addProjectPopup, ProjectsViewModel projectsViewModel)
        {
            InitializeComponent();

            _addProjectPopup = addProjectPopup;
            _projectsViewModel = projectsViewModel;

            RefreshProjects();
        }

        private void RefreshProjects()
        {
            var projects = _projectsViewModel.GetProjects();
            ProjectsListView.ItemsSource = projects;
        }

        private void AddProjectButton_Click(object sender, RoutedEventArgs e)
        {
            _addProjectPopup.ShowDialog(); // Use ShowDialog to make it a modal window
            RefreshProjects();
        }
    }
}
