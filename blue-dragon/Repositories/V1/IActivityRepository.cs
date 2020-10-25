using blue_dragon.Models.V1;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blue_dragon.Repositories
{
    public interface IActivityRepository : IRepository<Activity>
    {
        Task<IEnumerable<Activity>> GetAllActivityOrderByDateDescendingAsync();
        Task<Activity> GetActivityByIdAsync(int id);

    }
}
