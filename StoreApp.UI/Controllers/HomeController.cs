using Microsoft.AspNetCore.Mvc;
using StoreApp.Repositories.Concrete;

namespace StoreApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly IRepositoryManager _repositoryManager;
    public HomeController(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }


    public IActionResult Index()
    {

        return View(_repositoryManager.Product.GetAllProducts(false));
    }
    public IActionResult GetProduct(int id)
    {
        var product = _repositoryManager.Product.GetOneProduct(id, true);
        return View(product);
    }
}

