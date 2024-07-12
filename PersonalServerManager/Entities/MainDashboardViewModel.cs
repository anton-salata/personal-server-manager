using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PersonalServerManager.Entities
{
    public class MainDashboardViewModel : DbConnectedViewModel
    {
        public StatisticsViewModel Stats { get; set; } = new StatisticsViewModel();
        public List<HistoryRecord> History { get; set; } = new List<HistoryRecord>();

        public MainDashboardViewModel(AppDbContext dbContext) : base(dbContext)
        {
            Stats.DeploymentsCount = 8;
            Stats.ScriptsCount = 28;
            Stats.ServersCount = 3;

            GenerateDummyHistoryRecords();
        }

        private void GenerateDummyHistoryRecords()
        {
            History.Add(new HistoryRecord { Title = "AWS Server 3, 72.210.67.11", Text = "The server has been updated with the latest patches and configurations", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.Success });
            History.Add(new HistoryRecord { Title = "AWS Server 9, 135.104.251.18", Text = "Performance optimizations have been applied to the server", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.Info });
            History.Add(new HistoryRecord { Title = "Lnx Mount Adams, 52.228.123.246", Text = "Script execution completed successfully", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.Success });
            History.Add(new HistoryRecord { Title = "Lockheed Skunk Works, 181.35.166.13", Text = "All data has been securely backed up", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.None });
            History.Add(new HistoryRecord { Title = "Srv Pine Bush, 79.211.63.156", Text = "Automated tests have confirmed that the deployment was successful", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.Warning });
            History.Add(new HistoryRecord { Title = "Groom Lake, , 229.214.160.62", Text = "Changes have been successfully deployed", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.Success });
            History.Add(new HistoryRecord { Title = "S4, HANGAR 1, 237.70.30.142", Text = "The deployment process has completed", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.Success });
            History.Add(new HistoryRecord { Title = "S4, HANGAR 8, 144.132.89.48", Text = "Comprehensive documentation for the latest deployment has been successfully published for reference", DateTime = DateTime.Now.AddDays(-3), Type = HistoryRecordType.Success });


            //// Dummy messages about servers, deployments, and scripts
            //string[] serverMessages = { "Server started successfully.", "Server configuration updated.", "Server health check passed" };
            //string[] deploymentMessages = { "Deployment completed without issues.", "Deployment successful.", "Deployment deployed to all servers." };
            //string[] scriptMessages = { "Script executed without errors.", "Script completed successfully." };

            //Random rand = new Random();

            //// Generate 10 random history records
            //for (int i = 0; i < 10; i++)
            //{
            //    string title, text;

            //    // Randomly select a message type (server, deployment, or script)
            //    int messageType = rand.Next(3);
            //    HistoryRecordType type = (HistoryRecordType)rand.Next(0, Enum.GetNames(typeof(HistoryRecordType)).Length);

            //    switch (messageType)
            //    {
            //        case 0: // Server message
            //            var server = GetRandomServer();
            //            title = $"{server.Name}, IP: {server.IP}";
            //            text = serverMessages[rand.Next(serverMessages.Length)];
            //            // Retrieve a random server from the database

            //            break;
            //        case 1: // Deployment message
            //            title = "Deployment";
            //            text = deploymentMessages[rand.Next(deploymentMessages.Length)];
            //            break;
            //        default: // Script message
            //            title = "Script";
            //            text = scriptMessages[rand.Next(scriptMessages.Length)];
            //            break;
            //    }

            //    // Create a new history record with random title, text, and date/time
            //    History.Add(new HistoryRecord
            //    {
            //        Title = title,
            //        Text = text,
            //        DateTime = DateTime.Now.AddDays(-i),
            //        Type = type
            //    });
            //}
        }


        private ServerDetails GetRandomServer()
        {
            var servers = new List<ServerDetails>()
            {
                new ServerDetails { Name = "Linux Home", IP = "127.0.0.1" },
                new ServerDetails { Name = "AWS One", IP = "127.0.0.2" },
                new ServerDetails { Name = "AWS Two", IP = "127.0.0.3" },
                new ServerDetails { Name = "Web Site Host Server", IP = "127.0.0.4" }
            };

            var rnd = new Random();

            return servers[rnd.Next(servers.Count())];
        }
    }

    public class HistoryRecord
    {
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime DateTime { get; set; }
        public HistoryRecordType Type { get; set; }
    }

    public enum HistoryRecordType
    {
        None,
        Success,
        Warning,
        Error,
        Info
    }
}