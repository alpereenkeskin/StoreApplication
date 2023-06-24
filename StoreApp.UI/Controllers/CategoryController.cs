using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Entites;
using StoreApp.Repositories.Concrete;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {

        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            return View(_serviceManager.CategoryService.GetAllCategories(false).ToList());
        }

    }
}