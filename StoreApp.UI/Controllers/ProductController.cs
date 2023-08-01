using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Entites.RequestParameters;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Controllers
{
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index(ProductRequestParameters productRequest)
        {
            var p = _serviceManager.ProductService.GetAllProductsWithDetails(productRequest);
            return View(p);
        }

    }
}