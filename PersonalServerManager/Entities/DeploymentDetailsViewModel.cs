using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class DeploymentDetailsViewModel
    {
        public string Name { get; set; }
        public ProjectDetails Source { get; set; }
        public ServerDetails Target { get; set; }
        public string Settings { get; set; }
        public string? Notes { get; set; }
    }
}
