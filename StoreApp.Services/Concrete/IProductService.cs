using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entites;


namespace StoreApp.Services.Concrete
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool asnoTracking);
        Product? GetOneProduct(int id, bool asnoTracking);

    }
}