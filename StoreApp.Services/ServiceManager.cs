using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StoreApp.Services.Concrete;

namespace StoreApp.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly ICategoryService _cateService;
        private readonly IProductService _productService;

        public ServiceManager(ICategoryService cateService, IProductService productService)
        {
            _cateService = cateService;
            _productService = productService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _cateService;
    }
}