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
using PersonalServerManager.Entities;

namespace PersonalServerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly ServersPage _serversPage;
        private readonly DashboardPage _dashboardPage;
        private readonly DeploymentsPage _deploymentsPage;

        public MainWindow(ServersPage serversPage, DashboardPage dashboardPage, DeploymentsPage deploymentsPage)
        {
            InitializeComponent();

            _serversPage = serversPage;
            _dashboardPage = dashboardPage;
            _deploymentsPage = deploymentsPage;

            // Navigate to the Dashboard page initially
            NavigateToDashboard();
        }

        private void NavigateToDashboard()
        {
            PageContainer.Children.Clear();
            PageContainer.Children.Add(_dashboardPage);
        }

        private void DashboardMenuItem_Click(object sender, RoutedEventArgs e)
        {
            NavigateToDashboard();
        }

        private void ServersMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Servers page
            PageContainer.Children.Clear();
            PageContainer.Children.Add(_serversPage);
        }

        private void ProjectsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Projects page
            // Implement your navigation logic here
        }

        private void DeploymentsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Settings page
            PageContainer.Children.Clear();
            PageContainer.Children.Add(_deploymentsPage);
        }
        private void SettingsMenuItem_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to Settings page
            // Implement your navigation logic here
        }
    }
}
