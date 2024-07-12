using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class ProjectDetails
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? Notes { get; set; }
    }
}
