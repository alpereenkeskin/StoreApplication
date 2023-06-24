using Microsoft.AspNetCore.Mvc;
using StoreApp.Repositories.Concrete;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Controllers;

public class HomeController : Controller
{


    private readonly IServiceManager _serviceManager;
    public HomeController(IServiceManager serviceManager)
    {
        _serviceManager = serviceManager;
    }


    public IActionResult Index()
    {
        return View(_serviceManager.ProductService.GetAllProducts(true));
    }
    public IActionResult GetProduct(int id)
    {
        var product = _serviceManager.ProductService.GetOneProduct(id, true);
        return View(product);
    }
}

