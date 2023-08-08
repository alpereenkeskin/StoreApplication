using Microsoft.EntityFrameworkCore;
using StoreApp.Entites;

namespace StoreApp.Repositories.RepositoriesExtensions
{
    public static class ProductRepositoryExtensions
    {
        public static IQueryable<Product> FilteredBySearchTerm(this IQueryable<Product> products, String? SearchTerm)
        {
            if (SearchTerm is not null)
            {
                return products.
                Include(x => x.Category).
                Where(x => x.ProductName.ToLower().Contains(SearchTerm.ToLower()));

            }
            return products;
        }

        public static IQueryable<Product> FilteredByCategoryId(this IQueryable<Product> products, int? categoryId)
        {
            if (categoryId is null)
            {
                return products;
            }
            return products.
            Include(x => x.Category).
            Where(x => x.CategoryId.Equals(categoryId));

        }
        public static IQueryable<Product> FilteredByPrice(this IQueryable<Product> products,int? maxPrice,int? minPrice)
        {
            if ((minPrice is null) && (maxPrice is null)) {
                return products;
            }
            return products
                .Include(x => x.Category)
                .Where(x => x.Price >= minPrice && x.Price <= maxPrice);
        }


    }
}