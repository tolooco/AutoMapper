using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tolooco.Data.Infrastructure
{
    public interface IDbFactory<TContext> : IDisposable where TContext : DbContext
    {
        TContext Init();
    }
}
