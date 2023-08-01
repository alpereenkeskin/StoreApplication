using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using StoreApp.Entites;
using StoreApp.Entites.RequestParameters;
using StoreApp.Repositories.Concrete;
using StoreApp.Services.Concrete;

namespace StoreApp.Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repoManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager repoManager, IMapper mapper)
        {
            _repoManager = repoManager;
            _mapper = mapper;
        }

        public void CreateProduct(ProductCreateDto productdto)
        {
            //Product product = new()
            //{
            //    ProductName = productdto.ProductName,
            //    Price = productdto.Price,
            //    CategoryId = productdto.CategoryId
            //};
            var product = _mapper.Map<Product>(productdto);
            _repoManager.Product.CreateProduct(product);
            _repoManager.Save();
        }

        public void DeleteProduct(int id)
        {
            var product = _repoManager.Product.GetOneProduct(id, true);
            if (product is not null)
            {
                _repoManager.Product.DeleteProduct(product);
                _repoManager.Save();
            }
            else
            {
                throw new Exception("Hata Silinemedi");
            }
        }
        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _repoManager.Product.GetAllProductsWithDetails(p);
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

        public ProductUpdateDto GetOneProductForUpdate(int id, bool asnoTracking)
        {

            var product = _repoManager.Product.GetOneProduct(id, asnoTracking);
            var productDto = _mapper.Map<ProductUpdateDto>(product);
            return productDto;
        }

        public IEnumerable<Product> GetShowcaseProducts(bool asnoTracking)
        {
            return _repoManager.Product.GetShowcaseProducts(asnoTracking);
        }

        public void UpdateProduct(ProductUpdateDto productdto)
        {
            var product = _mapper.Map<Product>(productdto);
            _repoManager.Product.UpdateOneProduct(product);
            _repoManager.Save();
        }
    }
}