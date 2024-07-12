using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalServerManager.Entities
{
    public abstract class DbConnectedViewModel : ViewModelBase
    {
        protected readonly AppDbContext _dbContext;

        protected DbConnectedViewModel(AppDbContext dbContext)
        {
            this._dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }
    }
}
