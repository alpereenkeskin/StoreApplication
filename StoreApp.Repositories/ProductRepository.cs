using Microsoft.EntityFrameworkCore;
using StoreApp.Entites;
using StoreApp.Entites.RequestParameters;
using StoreApp.Repositories.Concrete;
using StoreApp.Repositories.RepositoriesExtensions;

namespace StoreApp.Repositories
{
    public sealed class ProductRepository : RepositoryBase<Product>, IProductRepository
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
            return _context
            .Products
            .FilteredByCategoryId(p.CategoryId)
            .FilteredBySearchTerm(p.SearchTerm)
            .FilteredByPrice(p.maxPrice, p.minPrice);
        }
    }
}