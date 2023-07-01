using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entites;
using StoreApp.Repositories.Concrete;

namespace StoreApp.Repositories
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(RepositoryDbContext context) : base(context)
        {
        }

        public void CreateProduct(Product product)
        {
             Create(product);
        }

        public void DeleteProduct(Product product) => Delete(product);
       
        

        public IQueryable<Product> GetAllProducts(bool asNoTracking)
        {
            return asNoTracking ?
             _context.Set<Product>()
             :
             _context.Set<Product>().AsNoTracking();
        }

        public Product? GetOneProduct(int id, bool asNoTracking)
        {
            return FindByCondition(x => x.ProductId == id, asNoTracking);
        }

        public void UpdateOneProduct(Product product) => Update(product);
    }
}