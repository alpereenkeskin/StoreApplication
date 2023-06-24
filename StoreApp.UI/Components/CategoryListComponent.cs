using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Components
{
    public class CategoryListComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoryListComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            return View(_serviceManager.CategoryService.GetAllCategories(true).ToList());
        }

    }
}