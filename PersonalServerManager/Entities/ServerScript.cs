using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class ServerScript
    {
        [Key]
        public int Id { get; set; }
        public int ServerId { get; set; }
        public string ScriptName { get; set; }
        public string ScriptText { get; set; }

        //[Column(TypeName = "json")]
        //public Dictionary<string, string> ScriptsParameters { get; set; }

    }
}