using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entites
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Product name is required")]
        public String? ProductName { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public decimal Price { get; set; }
        public String? Summary { get; set; }
        public String? ImagePath { get; set; }
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public bool Showcase { get; set; }
    }

}