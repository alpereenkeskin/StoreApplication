using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entites;

namespace StoreApp.Repositories.Concrete
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool asNoTracking);
        Product? GetOneProduct(int id, bool asNoTracking);
    }
}