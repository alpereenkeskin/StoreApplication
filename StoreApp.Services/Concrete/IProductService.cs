using StoreApp.Entites;
using StoreApp.Entites.Dtos;
using StoreApp.Entites.RequestParameters;

namespace StoreApp.Services.Concrete
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool asnoTracking);
        IEnumerable<Product> GetShowcaseProducts(bool asnoTracking);
        IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p);
        Product? GetOneProduct(int id, bool asnoTracking);
        void CreateProduct(ProductCreateDto productDto);
        void UpdateProduct(ProductUpdateDto productdto);
        void DeleteProduct(int id);
        ProductUpdateDto GetOneProductForUpdate(int id, bool asnoTracking);
    }
}