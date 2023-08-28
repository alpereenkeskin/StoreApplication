using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.API
{
    [ApiController]
    [Route("/API/{controller}")]
    public class ProductsController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult GetAllProducts()
        {
            return Ok(_serviceManager.ProductService.GetAllProducts(false));
        }

    }

}