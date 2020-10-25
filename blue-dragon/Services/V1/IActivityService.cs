using blue_dragon.Models.V1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blue_dragon.Service.V1
{
    public interface IActivityService
    {
        Task<IEnumerable<Activity>> GetAllActivity();
        Task<Activity> GetActivityById(int id);
        Task<Activity> createActivity(Activity activity);
        Task UpdateActivityStatus(Activity activityToBeUpdated, String status);
        Task DeleteActivity(Activity activity);

    }
}
