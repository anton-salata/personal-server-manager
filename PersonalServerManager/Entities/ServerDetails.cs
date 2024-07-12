using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class ServerDetails
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? IP { get; set; }
        public string? User { get; set; }
        public string? Password { get; set; }
        public string? Notes { get; set; }       
    }
}
