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
    /// Interaction logic for DeploymentsPage.xaml
    /// </summary>
    public partial class DeploymentsPage : UserControl
    {
        private DeplymentsViewModel _deplymentsViewModel;
        public DeploymentsPage(DeplymentsViewModel deplymentsViewModel)
        {
            InitializeComponent();

            _deplymentsViewModel = deplymentsViewModel;

            RefreshDeployments();
        }

        private void RefreshDeployments()
        {
            var deployemnts = _deplymentsViewModel.GetDeployments();
            DeployemntsListView.ItemsSource = deployemnts;
        }
    }
}
