using Tolooco.Data.Infrastructure;
using Tolooco.Domain.Models;
using System.Collections.Generic;
using System.Linq;
using Tolooco.Data.Repositories;
using Tolooco.Data.DatabaseContext;

namespace Tolooco.Service
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetCategories(string name = null);
        Category GetCategory(int id);
        Category GetCategory(string name);
        void CreateCategory(Category category);
        void SaveCategory();
    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categorysRepository;
        private readonly IUnitOfWork<FirstDb> unitOfWork;

        public CategoryService(ICategoryRepository categorysRepository, IUnitOfWork<FirstDb> unitOfWork)
        {
            this.categorysRepository = categorysRepository;
            this.unitOfWork = unitOfWork;
        }

        #region ICategoryService Members

        public IEnumerable<Category> GetCategories(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return categorysRepository.GetAll();
            else
                return categorysRepository.GetAll().Where(c => c.Name == name);
        }

        public Category GetCategory(int id)
        {
            var category = categorysRepository.GetById(id);
            return category;
        }

        public Category GetCategory(string name)
        {
            var category = categorysRepository.GetCategoryByName(name);
            return category;
        }

        public void CreateCategory(Category category)
        {
            categorysRepository.Insert(category);
        }

        public void SaveCategory()
        {
            unitOfWork.Commit();
        }

        #endregion
    }
}
