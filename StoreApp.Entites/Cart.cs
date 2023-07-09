using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entites
{
    public class Cart
    {
        public List<CartLine> CartLines { get; set; }

        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public void AddItem(Product product, int quantity)
        {
            CartLine? line = CartLines.Where(x => x.Product.ProductId == product.ProductId).FirstOrDefault();
            if (line is null)
                CartLines.Add(
                    new CartLine()
                    {
                        Product = product,
                        Quantity = quantity
                    }
                );
            else
                line.Quantity += quantity;
        }

        public void RemoveAll(Product product) => CartLines.RemoveAll(x => x.Product.ProductId == product.ProductId);

        public decimal ComputeTotalValue() => CartLines.Sum(x => x.Product.Price * x.Quantity);

        public void Clear() => CartLines.Clear();

    }
}