using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entites;
using StoreApp.Repositories.Concrete;
using StoreApp.Services.Concrete;

namespace StoreApp.Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repoManager;

        public ProductManager(IRepositoryManager repoManager)
        {
            _repoManager = repoManager;
        }

        public IEnumerable<Product> GetAllProducts(bool asnoTracking)
        {
            return _repoManager.Product.FindAll(asnoTracking);
        }

        public Product? GetOneProduct(int id, bool asnoTracking)
        {
            var t = _repoManager.Product.FindByCondition(x => x.ProductId == id, asnoTracking);
            if (t is null)
                throw new Exception("Hata");
            else
                return t;
        }
    }
}