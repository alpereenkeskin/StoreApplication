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
        private readonly IOrderService _orderService;

        public ServiceManager(ICategoryService cateService, IProductService productService, IOrderService orderService)
        {
            _cateService = cateService;
            _productService = productService;
            _orderService = orderService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _cateService;
        public IOrderService OrderService => _orderService;
    }
}