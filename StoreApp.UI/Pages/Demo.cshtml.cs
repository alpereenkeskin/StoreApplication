using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace StoreApp.UI.Pages
{
    public class DemoModel : PageModel
    {
        public String? FullName => HttpContext?.Session?.GetString("name") ?? "NoName"; // ve modeldeki propertye atadığım session u veriyorum.
        public void OnGet()
        {

        }
        public void OnPost(string name) // burada kullanıcı giriş yaptığında httpcontext üzerinden session nu set ediyorum.
        {
            HttpContext.Session.SetString("name", name);
        }
    }
}
