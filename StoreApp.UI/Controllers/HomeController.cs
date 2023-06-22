using Microsoft.AspNetCore.Mvc;
using StoreApp.Repositories;


namespace StoreApp.UI.Controllers;

public class HomeController : Controller
{
    private readonly RepositoryDbContext _context;
    public HomeController(RepositoryDbContext context)
    {
        _context = context;
    }


    public IActionResult Index()
    {
        return View(_context.Products.ToList());
    }
    public IActionResult GetProduct(int id)
    {
        if (id != 0)
        {
            var product = _context.Products.Find(id);
            return View(product);
        }
        return View();
    }
}

