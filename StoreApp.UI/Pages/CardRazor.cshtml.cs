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
            Cart = cart;
            _serviceManager = serviceManager;

        }
        public string ReturnUrl { get; set; } = "/";

        // Onget() sayfa yüklendiğinde çalışacak olan metotdur.Ve çalışacak olan işlemleri belirtir.Ornek veritabanından kullanıcı çekmek için kullanılabilir.
        public void OnGet(string returnUrl)// kullanıcı hangi sayfadan buraya eriştiyse o bilgiyi tutmak için değişken tanımlıyoruz. örnek olarak sepete baktığında aynı sayfaya geri dönebilsin.
        {
            ReturnUrl = returnUrl ?? "/"; // eğer return url boş ise tekrar ana sayfadau göndersin 


        }
        public IActionResult OnPost(int productId, string returnUrl)// Sayfadan sepete eklenen ürünleri seçmek için productId ile onları alıyoruz.
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