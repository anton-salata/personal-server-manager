using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
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
using PersonalServerManager.Entities;

namespace PersonalServerManager
{
    /// <summary>
    /// Interaction logic for AddServerPopup.xaml
    /// </summary>

    public partial class AddServerPopup : Window
    {
        private readonly AppDbContext _dbContext;

        public AddServerPopup(AppDbContext dbContext)
        {
            InitializeComponent();

            _dbContext = dbContext;
        }

        private void AddServerButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            string ip = IPTextBox.Text;
            string user = UserTextBox.Text;
            string password = PasswordBox.Password;
            string notes = NotesTextBox.Text;

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(ip) || string.IsNullOrEmpty(user) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            try
            {
                var serverDetails = new ServerDetails
                {
                    IP = ip,
                    Name = name,
                    User = user,
                    Password = password,
                    Notes = notes
                };

                _dbContext.ServersDetails.Add(serverDetails);

                _dbContext.SaveChanges();

                var serverScritps = GetScriptTemplates().Select(t =>
                {
                    return new ServerScript
                    {
                        ScriptName = t.Key,
                        ScriptText = t.Value,
                        ServerId = serverDetails.Id
                    };
                });

                _dbContext.ServerScripts.AddRange(serverScritps);

                _dbContext.SaveChanges();

                MessageBox.Show("Server added successfully.");
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private Dictionary<string, string> GetScriptTemplates()
        {
            // Get the directory where the executable is located
            string exePath = Assembly.GetEntryAssembly().Location;
            string exeDirectory = System.IO.Path.GetDirectoryName(exePath);

            // Construct the path to the "Scripts" folder
            string scriptsFolderPath = System.IO.Path.Combine(exeDirectory, "Scripts");

            var scripts = new Dictionary<string, string>();
            // Check if the "Scripts" folder exists
            if (Directory.Exists(scriptsFolderPath))
            {
                // Get the files in the "Scripts" folder
                string[] scriptFiles = Directory.GetFiles(scriptsFolderPath);

                // Process each file
                foreach (string filePath in scriptFiles)
                {
                    // Read the contents of the file
                    string fileContent = File.ReadAllText(filePath);
                    scripts.Add(System.IO.Path.GetFileName(filePath), fileContent);

                    // Do something with the file content
                    //Console.WriteLine($"File: {System.IO.Path.GetFileName(filePath)}");
                    //Console.WriteLine($"Content: {fileContent}");
                }
            }

            return scripts;
        }
    }

}
