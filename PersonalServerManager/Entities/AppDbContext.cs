using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class AppDbContext : DbContext
    {
        public DbSet<ServerDetails> ServersDetails { get; set; }
        public DbSet<ProjectDetails> ProjectsDetails { get; set; }
        public DbSet<DeploymentDetails> DeploymentsDetails { get; set; }
        public DbSet<ServerScript> ServerScripts { get; set; }
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=app.db");
        }
    }
}
