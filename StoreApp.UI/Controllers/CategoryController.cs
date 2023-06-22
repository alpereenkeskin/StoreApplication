using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Entites;
using StoreApp.Repositories.Concrete;

namespace StoreApp.UI.Controllers
{
    [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IActionResult Index()
        {
            return View(_repositoryManager.Category.FindAll(true).ToList());
        }

    }
}