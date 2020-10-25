using blue_dragon.Models.V1;
using blue_dragon.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blue_dragon.Data.Repositories.Impl
{
    public class ActivityRepository : Repository<Activity>, IActivityRepository
    {
        public ActivityRepository(BlueDragonDbContext context)
      : base(context)
        { }

        public async Task<Activity> GetActivityByIdAsync(int id)
        {
            return await BlueDragonDbContext.Activities.FindAsync(id);
        }

        public async Task<IEnumerable<Activity>> GetAllActivityOrderByDateDescendingAsync()
        {
            return await BlueDragonDbContext.Activities.OrderByDescending(x => x.DateTime).ToListAsync();
        }


        private BlueDragonDbContext BlueDragonDbContext
        {
            get { return Context as BlueDragonDbContext; }
        }
    }
}
