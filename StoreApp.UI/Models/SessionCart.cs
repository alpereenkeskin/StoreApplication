using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using StoreApp.Entites;
using StoreApp.UI.Infrastructe.Extensions;

namespace StoreApp.UI.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession? Session { get; set; }

        public static Cart GetCart(IServiceProvider services)
        {
            HttpContext? context = services.GetRequiredService<IHttpContextAccessor>().HttpContext;
            if (context == null)
            {
                // HttpContext yok, bu durumda arka plan işlemleri veya testler için geçici bir çözüm olabilir.
                return new SessionCart();
            }

            ISession session = context.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product, int quantity)
        {
            base.AddItem(product, quantity);
            Session?.SetJson<SessionCart>("cart", this);
        }
        public override void Clear()
        {
            base.Clear();
            Session?.Remove("cart");
        }
        public override void RemoveAll(Product product)
        {
            base.RemoveAll(product);
            Session?.SetJson<SessionCart>("cart", this);
        }

    }
}