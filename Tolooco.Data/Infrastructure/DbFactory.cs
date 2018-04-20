using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tolooco.Data.Infrastructure
{
    public class DbFactory<TContext> : Disposable, IDbFactory<TContext> where TContext : DbContext, new()
    {
        TContext dbContext;

        public TContext Init()
        {
            return dbContext ?? (dbContext = new TContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
