using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreApp.Entites;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Controllers
{

    public class OrderController : Controller
    {
        private readonly Cart _cart;
        private readonly IServiceManager _serviceManager;

        public OrderController(Cart cart, IServiceManager serviceManager)
        {
            _cart = cart;
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Checkout() => View(new Order());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Checkout(Order order)
        {
            if (_cart.CartLines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry. Your cart is empty");
            }
            if (ModelState.IsValid)
            {
                order.CartLines = _cart.CartLines;
                _serviceManager.OrderService.SaveOrder(order);
                _cart.Clear();
            }
            return RedirectToPage("/Complete", new { orderId = order.OrderId });
        }
    }

}