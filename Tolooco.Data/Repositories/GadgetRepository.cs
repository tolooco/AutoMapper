using System.Data.Entity;
using Tolooco.Data.DatabaseContext;
using Tolooco.Data.Infrastructure;
using Tolooco.Domain.Models;

namespace Tolooco.Data.Repositories
{
    public interface IGadgetRepository : IRepository<Gadget>
    {

    }

    public class GadgetRepository : Repository<Gadget>, IGadgetRepository
    {
        public GadgetRepository(IDbFactory<FirstDb> dbFactory)
             : base(dbFactory) { }
    }


}
