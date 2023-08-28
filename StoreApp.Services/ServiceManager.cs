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
        private readonly IAuthService _authService;

        public ServiceManager(ICategoryService cateService, IProductService productService, IOrderService orderService, IAuthService authService)
        {
            _cateService = cateService;
            _productService = productService;
            _orderService = orderService;
            _authService = authService;
        }

        public IProductService ProductService => _productService;
        public ICategoryService CategoryService => _cateService;
        public IOrderService OrderService => _orderService;

        public IAuthService AuthService => _authService;
    }
}