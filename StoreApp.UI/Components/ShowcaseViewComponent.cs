using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public ShowcaseViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke()
        {
            var p = _serviceManager.ProductService.GetShowcaseProducts(false);
            return View(p);
        }

    }
}