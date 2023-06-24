using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Repositories;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Components
{
    public class ProductSummary : ViewComponent
    {
        private readonly RepositoryDbContext _context;
        private readonly IServiceManager _serviceManager;

        public ProductSummary(RepositoryDbContext context, IServiceManager serviceManager)
        {
            _context = context;
            _serviceManager = serviceManager;
        }

        public String Invoke()
        {
            return _serviceManager.ProductService.GetAllProducts(false).Count().ToString();
        }

    }
}