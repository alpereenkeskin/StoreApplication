using StoreApp.Entites;
using StoreApp.Entites.Dtos;



namespace StoreApp.Services.Concrete
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts(bool asnoTracking);
        Product? GetOneProduct(int id, bool asnoTracking);
        void CreateProduct(ProductCreateDto productDto);
        void UpdateProduct(ProductUpdateDto productdto);
        void DeleteProduct(int id);
        ProductUpdateDto GetOneProductForUpdate(int id, bool asnoTracking);
    }
}