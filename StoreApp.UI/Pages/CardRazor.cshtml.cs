using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Entites;
using StoreApp.Services.Concrete;

namespace StoreApp.UI.Pages
{
    public class CardRazor : PageModel
    {
        private readonly IServiceManager _serviceManager;
        public Cart Cart { get; set; }

        public CardRazor(IServiceManager serviceManager, Cart cart)
        {
            _serviceManager = serviceManager;
            Cart = cart;
        }


        public string ReturnUrl { get; set; } = "/";

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";


        }
        public IActionResult OnPost(int productId, string returnUrl)
        {
            Product? product = _serviceManager
            .ProductService
            .GetOneProduct(productId, false);

            if (product is not null)
            {
                Cart.AddItem(product, 1);
            }
            return Page();
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            Cart.RemoveAll(Cart.CartLines.First(x => x.Product.ProductId == productId).Product);
            return Page();
        }
    }
}