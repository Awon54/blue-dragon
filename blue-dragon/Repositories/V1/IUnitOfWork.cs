using blue_dragon.Repositories;
using System;
using System.Threading.Tasks;

namespace blue_dragon.Data.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IActivityRepository Activities { get; }
        Task<int> CommitAsync();

    }
}
