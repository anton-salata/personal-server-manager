using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class DeploymentDetails
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Notes { get; set; }
        public int ProjectId { get; set; }
        public int ServerId { get; set; }
        //public ServiceDeploymentSettings ServiceDeploymentSettings { get; set; }
        //public WebSiteDeploymentSettings WebSiteDeploymentSettings { get; set; }
    }

    public enum DeploymentType
    {
        NotSet = 0,
        WebSite = 1,
        Service = 2
    }

    public class ServiceDeploymentSettings
    {

    }

    public class WebSiteDeploymentSettings
    {
    }
}
