using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public OrderController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var orders = _serviceManager.OrderService.Orders.ToList();
            return View(orders);
        }
        [HttpPost]
        public IActionResult Complete(int id)
        {
            _serviceManager.OrderService.Complete(id);
            return RedirectToAction("Index");
        }

    }
}