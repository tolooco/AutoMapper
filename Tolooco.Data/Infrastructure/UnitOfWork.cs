using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tolooco.Data.DatabaseContext;
using Tolooco.Data.Repositories;

namespace Tolooco.Data.Infrastructure
{
    public class UnitOfWork<TContext> : IUnitOfWork<TContext>
        where TContext : DbContext, new()
    {
        #region Fields
        private readonly IDbFactory<FirstDb> dbFactory;
        private FirstDb dbContext;
        #endregion

        #region Ctor
        public UnitOfWork(IDbFactory<FirstDb> dbFactory)
        {
            this.dbFactory = dbFactory;
        }

        public FirstDb DbContext
        {
            get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        #endregion

        #region Implement
        public void Commit()
        {
            DbContext.Commit();
        }

        public Task<int> CommitAsync()
        {
            return DbContext.SaveChangesAsync();
        }

        #endregion

    }
}
