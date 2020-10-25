using blue_dragon.Data.Repositories.Impl;
using blue_dragon.Repositories;
using System.Threading.Tasks;

namespace blue_dragon.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BlueDragonDbContext _context;
        private ActivityRepository _activityRepository;


        public UnitOfWork(BlueDragonDbContext context)
        {
            this._context = context;
        }

        public IActivityRepository Activities => _activityRepository = _activityRepository ?? new ActivityRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
