using System;
using System.ComponentModel.DataAnnotations;

namespace StoreApp.Entites.Dtos
{
    public record ProductDto //burada record genellikle dto lar tanımlanırken kullanılır
    {
        public int ProductId { get; init; }
        public String? ProductName { get; init; }
        public decimal Price { get; init; }
        public String? Summary { get; init; }
        public String? ImagePath { get; set; }
        public int CategoryId { get; init; }
        //init yapmamızın sebebi veri olusturulurken set olur değiştirilbililir fakat veri oluştuktan sonta değişikliğe izin verilmez;
        // record özelliği immutable özelliği
    }
}

