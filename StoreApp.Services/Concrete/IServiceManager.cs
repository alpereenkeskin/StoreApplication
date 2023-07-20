using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Services.Concrete
{
    public interface IServiceManager
    {
        public IProductService ProductService { get; }
        public ICategoryService CategoryService { get; }
        public IOrderService OrderService { get; }
    }
}