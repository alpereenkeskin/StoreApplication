using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entites;

namespace StoreApp.Repositories
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.ProductId);
            builder.Property(x => x.ProductName).IsRequired();
            builder.Property(x => x.ProductName).IsRequired();
            builder.HasOne(x => x.Category).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);
            builder.HasData(
                new Product() { ProductId = 4, ImagePath = "/images/1.jpg", CategoryId = 1, ProductName = "deneme2", Showcase = false },
                new Product() { ProductId = 5, ImagePath = "/images/2.jpg", CategoryId = 2, ProductName = "deneme3", Showcase = false },
                new Product() { ProductId = 6, ImagePath = "/images/3.jpg", CategoryId = 3, ProductName = "deneme4", Showcase = false },
                new Product() { ProductId = 7, ImagePath = "/images/4.jpg", CategoryId = 1, ProductName = "deneme5", Showcase = false },
                new Product() { ProductId = 8, ImagePath = "/images/5.jpg", CategoryId = 2, ProductName = "deneme6", Showcase = false },
                new Product() { ProductId = 9, ImagePath = "/images/3.jpg", CategoryId = 3, ProductName = "DENEMEYENI1", Showcase = true },
                new Product() { ProductId = 10, ImagePath = "/images/4.jpg", CategoryId = 1, ProductName = "DENEMEYENI2", Showcase = true },
                new Product() { ProductId = 11, ImagePath = "/images/5.jpg", CategoryId = 2, ProductName = "DENEMEYENI3", Showcase = true }

            );

        }
    }

}