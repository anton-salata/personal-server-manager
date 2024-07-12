using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class DeplymentsViewModel : ViewModelBase
    {

        private readonly AppDbContext _dbContext;

        public DeplymentsViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DeploymentDetailsViewModel> GetDeployments() { 
            var deployments = new List<DeploymentDetailsViewModel>();

            // Add dummy data to the list
            deployments.Add(new DeploymentDetailsViewModel()
            {
                Name = "Deployment 1",
                Source = new ProjectDetails()
                {
                    Name = "Byte Buster",
                    Path = "E:\\X_marks_the_spot\\ByteBuster.sln",
                    Notes = "Lorem ipsum dolor sit amet, consectetur adipiscing elit."
                },
                Target = new ServerDetails()
                {
                    Name = "AWS Server 1",
                    IP = "192.168.1.100",
                    User = "admin",
                    Password = "password",
                    Notes = "Nulla facilisi. Vestibulum vel velit quis diam elementum gravida."
                },
                Settings = "Type A",
                Notes = "Duis id ligula non nisl rhoncus posuere."
            });

            deployments.Add(new DeploymentDetailsViewModel()
            {
                Name = "Deployment 2",
                Source = new ProjectDetails()
                {
                    Name = "Error Exorcist",
                    Path = "E:\\Apocalypse\\SurvivalGuide\\ErrorExorcist_v3.sln",
                    Notes = "Sed euismod consectetur sapien, id consequat purus rutrum eget."
                },
                Target = new ServerDetails()
                {
                    Name = "Home Server",
                    IP = "192.168.1.101",
                    User = "admin",
                    Password = "password",
                    Notes = "Vivamus fringilla velit sed finibus scelerisque."
                },
                Settings = "Type B",
                Notes = "Fusce mollis quam eu massa convallis."
            });

            deployments.Add(new DeploymentDetailsViewModel()
            {
                Name = "Deployment 3",
                Source = new ProjectDetails()
                {
                    Name = "Cyber Conjurer",
                    Path = "F:\\AI_Brain\\Emotion_Chip\\CyberConjure.sln",
                    Notes = "In pulvinar mauris vehicula."
                },
                Target = new ServerDetails()
                {
                    Name = "Area 51 Remote",
                    IP = "192.168.1.102",
                    User = "admin",
                    Password = "password",
                    Notes = "Vivamus fringilla velit sed finibus scelerisque."
                },
                Settings = "Type C",
                Notes = "In pulvinar mauris vehicula."
            });

            return deployments;
        }
    }
}
