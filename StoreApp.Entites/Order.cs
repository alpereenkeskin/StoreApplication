using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreApp.Entites
{
    public class Order
    {
        public int OrderId { get; set; }
        public ICollection<CartLine> CartLines { get; set; } = new List<CartLine>(); // varsayılan olarak boş bir cartline listesi veriyoruz.

        [Required(ErrorMessage = "Name is Required")]
        public String? Name { get; set; }

        [Required(ErrorMessage = "Line1 is Required")]
        public String? Line1 { get; set; }
        public String? Line2 { get; set; }
        public String? Line3 { get; set; }
        public String? City { get; set; }
        public bool GiftWrap { get; set; }
        public bool Shipped { get; set; }
        public DateTime OrderedAt { get; set; } = DateTime.Now;
    }
}