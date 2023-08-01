using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StoreApp.Entites;
using StoreApp.Entites.RequestParameters;
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

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
            .Where(x => x.Showcase.Equals(true));
            // throw new NotImplementedException();
        }

        public void UpdateOneProduct(Product product) => Update(product);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return p is null
            ? _context
            .Products
            .Include(x => x.Category)
            :
            _context
            .Products
            .Include(x => x.Category)
            .Where(x => x.CategoryId == p.CategoryId);
        }
    }
}