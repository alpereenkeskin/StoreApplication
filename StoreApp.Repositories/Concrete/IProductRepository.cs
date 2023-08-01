using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Entites;
using StoreApp.Entites.RequestParameters;

namespace StoreApp.Repositories.Concrete
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool asNoTracking);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        IQueryable<Product> GetShowcaseProducts(bool trackChanges);
        Product? GetOneProduct(int id, bool asNoTracking);
        void CreateProduct(Product product);
        void DeleteProduct(Product product);
        void UpdateOneProduct(Product product);
    }
}