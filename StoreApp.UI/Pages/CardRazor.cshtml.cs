using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using StoreApp.Entites;
using StoreApp.Services.Concrete;
using StoreApp.UI.Infrastructe.Extensions;

namespace StoreApp.UI.Pages
{
    public class CardRazor : PageModel
    {
        private readonly IServiceManager _serviceManager;
        public Cart Cart { get; set; }

        public CardRazor(IServiceManager serviceManager, Cart cartservice)
        {

            _serviceManager = serviceManager;
            Cart = cartservice;
        }
        public string ReturnUrl { get; set; } = "/";

        // Onget() sayfa yüklendiğinde çalışacak olan metotdur.Ve çalışacak olan işlemleri belirtir.Ornek veritabanından kullanıcı çekmek için kullanılabilir.
        public void OnGet(string returnUrl)// kullanıcı hangi sayfadan buraya eriştiyse o bilgiyi tutmak için değişken tanımlıyoruz. örnek olarak sepete baktığında aynı sayfaya geri dönebilsin.
        {

            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); // eğer CART türünde nesne var ise onu Deserialize ile c# class türüne dönüştürüyoruz. eğer yok ise yeni bir cart nesnesi oluşturuyoruz.
            ReturnUrl = returnUrl ?? "/"; // eğer return url boş ise tekrar ana sayfadau göndersin 
        }
        public IActionResult OnPost(int productId, string returnUrl)// Sayfadan sepete eklenen ürünleri seçmek için productId ile onları alıyoruz.
        {
            Product? product = _serviceManager
            .ProductService
            .GetOneProduct(productId, false);

            if (product is not null)
            {
                //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart(); // Cart nesnesini Session dan okuyoruz eğer yoksa oluşturuyoruz. GetJson Deserialize ederek bize bir class verdi.
                Cart.AddItem(product, 1);
                //HttpContext.Session.SetJson<Cart>("cart", Cart);
            }
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int productId, string returnUrl)
        {
            //Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            Cart.RemoveAll(Cart.CartLines.First(x => x.Product.ProductId == productId).Product);
            //HttpContext.Session.SetJson<Cart>("cart", Cart);
            return Page();
        }
    }
}