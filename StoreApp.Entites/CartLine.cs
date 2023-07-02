using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entites
{
    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; } = new();
        public int Quantity { get; set; }

    }
}