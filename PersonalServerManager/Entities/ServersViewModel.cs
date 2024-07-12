using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public class ServersViewModel
    {
        private readonly AppDbContext _dbContext;

        public ServersViewModel(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<ServerDetails> GetServers()
        {
            return _dbContext.ServersDetails.ToList();
        }

        public ServerDetails GetServerDetails(int serverId)
        {
            // Example method to fetch server details from the database by ID
            var server = _dbContext.ServersDetails.FirstOrDefault(s => s.Id == serverId);

            return server;
        }

        public IEnumerable<ServerScript> GetServerScripts(int serverId)
        {
            // Example method to fetch server details from the database by ID
            var serverScripts = _dbContext.ServerScripts.Where(s => s.ServerId == serverId).ToList();

            return serverScripts;
        }
    }
}
