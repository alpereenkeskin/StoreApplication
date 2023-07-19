using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StoreApp.Entites;

namespace StoreApp.UI.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly Cart _cart;

        public CartSummary(Cart cart)
        {
            _cart = cart;
        }

        public string Invoke()
        {
            var t = _cart.CartLines.Count.ToString();
            return t;
        }

    }
}