using System.Data.Entity;
using System.Threading.Tasks;
using Tolooco.Domain.Models;

namespace Tolooco.Data.DatabaseContext
{
    public class FirstDb : DbContext
    {
        static  FirstDb()
        {
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<FirstDb>());
        }

        public FirstDb():base("FirstDb")
        {

        }

        public virtual void Commit()
        {
            base.SaveChanges();
        }
        public virtual Task<int> CommitAsync()
        {
            return SaveChangesAsync();
        }

        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
