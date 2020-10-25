using blue_dragon.Data.Repositories;
using blue_dragon.Models.V1;
using blue_dragon.Service.V1;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace blue_dragon.Services.V1.Impl
{
    public class ActivityService : IActivityService
    {

        private readonly IUnitOfWork _unitOfWork;

        public ActivityService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Activity> GetActivityById(int id)
        {
            return await _unitOfWork.Activities
               .GetActivityByIdAsync(id);
        }

        public async Task<IEnumerable<Activity>> GetAllActivity()
        {
            return await _unitOfWork.Activities
              .GetAllActivityOrderByDateDescendingAsync();
        }

        public async Task UpdateActivityStatus(Activity activityToBeUpdated, String status)
        {
            activityToBeUpdated.Status = status;
            await _unitOfWork.CommitAsync();
        }

        public async Task<Activity> createActivity(Activity activity)
        {
            activity.DateTime = DateTime.UtcNow;
            await _unitOfWork.Activities.AddAsync(activity);
            await _unitOfWork.CommitAsync();
            return activity;
        }

        public async Task DeleteActivity(Activity activity)
        {
            _unitOfWork.Activities.Remove(activity);
            await _unitOfWork.CommitAsync();
        }


    }
}
