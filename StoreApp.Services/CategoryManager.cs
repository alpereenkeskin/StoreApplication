using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entites;
using StoreApp.Repositories.Concrete;
using StoreApp.Services.Concrete;

namespace StoreApp.Services
{
    public class CategoryManager : ICategoryService
    {
        private readonly IRepositoryManager _repoManager;

        public CategoryManager(IRepositoryManager repoManager)
        {
            _repoManager = repoManager;
        }

        public IEnumerable<Category> GetAllCategories(bool asnoTracking)
        {
            return _repoManager.Category.FindAll(asnoTracking);
        }

        public Category? GetOneCategory(int id, bool asnoTracking)
        {
            var cate = _repoManager.Category.FindByCondition(x => x.CategoryId == id, asnoTracking);
            if (cate is null)
                throw new Exception("Hata");
            else
                return cate;
        }
    }
}