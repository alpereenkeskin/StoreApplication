using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entites;

namespace StoreApp.Services.Concrete
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAllCategories(bool asnoTracking);
        Category? GetOneCategory(int id, bool asnoTracking);
    }
}