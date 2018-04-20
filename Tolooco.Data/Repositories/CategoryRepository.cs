using Tolooco.Data.DatabaseContext;
using Tolooco.Data.Infrastructure;
using Tolooco.Domain.Models;
using System;
using System.Data.Entity;

namespace Tolooco.Data.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetCategoryByName(string categoryName);
    }

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(IDbFactory<FirstDb> dbFactory)
           : base(dbFactory) { }

        public Category GetCategoryByName(string categoryName)
        {
            var category = Get(c => c.Name == categoryName);

            return category;
        }

        public override void Update(Category entity)
        {
            entity.DateUpdated = DateTime.Now;
            base.Update(entity);
        }
    }

   
}
