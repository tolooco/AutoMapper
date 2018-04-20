using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Tolooco.Data.Repositories;

namespace Tolooco.Data.Infrastructure
{
    public interface IUnitOfWork<TContext> where TContext:DbContext
    {
        void Commit();

        Task<int> CommitAsync();
    }
}
