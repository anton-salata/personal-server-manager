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
    /// Interaction logic for ServersPage.xaml
    /// </summary>
    public partial class ServersPage : UserControl
    {
        private readonly AddServerPopup _addServerPopup;
        private readonly ServersViewModel _serversViewModel;
        public ServersPage(AddServerPopup addServerPopup, ServersViewModel serversViewModel)
        {
            InitializeComponent();

            _addServerPopup = addServerPopup;
            _serversViewModel = serversViewModel;

            RefreshServers();
        }

        private void AddServerButton_Click(object sender, RoutedEventArgs e)
        {
            // Open the AddServerPopup
            _addServerPopup.ShowDialog(); // Use ShowDialog to make it a modal window
            RefreshServers();
        }

        private void ServersListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedServer = ServersListView.SelectedItem as ServerDetails;
            if (selectedServer == null)
                return;

            var serverDetails = _serversViewModel.GetServerDetails(selectedServer.Id);
            var serverScripts = _serversViewModel.GetServerScripts(selectedServer.Id).Select(s => new ScriptViewModel()
            {
                Name = s.ScriptName,
                Content = s.ScriptText,
                //Parameters = s.ScriptsParameters
            });

            var serverDetailsViewModel = new ServerDetailsViewModel()
            {
                ServerDetails = serverDetails
            };

            foreach (var script in serverScripts)
            {
                serverDetailsViewModel.Scripts.Scripts.Add(script);
            }

            var serverDetailsWindow = new ServerDetailsWindow(serverDetailsViewModel);
            serverDetailsWindow.Show();
        }

        private void RefreshServers()
        {
            var servers = _serversViewModel.GetServers();
            ServersListView.ItemsSource = servers;


            //var srvrs = new List<ServerDetails>()
            //{
            //      new ServerDetails { Name = "Area51 SuperServer", IP = "192.168.10.11", Notes = "Access granted only to those who can decode alien hieroglyphics" },
            //new ServerDetails { Name = "Roswell Storage Master", IP = "192.168.20.22", Notes = "Classified files related to the 1947 Roswell UFO incident. Beware of alien gremlins causing occasional data glitches" },
            //new ServerDetails { Name = "MIB Data Center", IP = "192.168.30.33", Notes = "Managed by the Men in Black, this server houses encrypted files containing evidence of extraterrestrial encounters. Warning: Neuralyzer protection in place" },
            //new ServerDetails { Name = "AlienTech PortalHub", IP = "192.168.40.44", Notes = "Direct link to advanced alien technology. Keep an eye out for suspiciously glowing USB ports" },
            //new ServerDetails { Name = "XFiles Central", IP = "192.168.50.55", Notes = "Contains unexplained phenomena reports, alien autopsy videos, and secret Masonic codes" },
            //new ServerDetails { Name = "Masonic Motherboard", IP = "192.168.60.66", Notes = "Use with caution. This server holds the key to unlocking the mysteries of the Masonic brotherhood and their connection to alien overlords" },
            //new ServerDetails { Name = "UFO Cloud Vault", IP = "192.168.70.77", Notes = "This server floats above the clouds, hidden from prying eyes. Contains blueprints for flying saucers and smoothie recipes" },
            //new ServerDetails { Name = "Galactic Gateway", IP = "192.168.80.88", Notes = "Watch out for spam. Hub for exchanging messages with friendly extraterrestrial civilizations. Assembled by an intergalactic coalition" },
            //new ServerDetails { Name = "Elders Server Sanctum", IP = "192.168.90.99", Notes = "Rumored to be overseen by ancient alien elders, this server holds the secrets of the universe, including the ultimate recipe for cosmic pizza" },
            //new ServerDetails { Name = "Conspiracy Control Center", IP = "192.168.100.101", Notes = "Run by lizard people, this server orchestrates global conspiracies involving aliens, Illuminati, and the secret society of sock-stealing gnomes" }

            //};

            //ServersListView.ItemsSource = srvrs;
        }
    }
}