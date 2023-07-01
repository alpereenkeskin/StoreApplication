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
                new Product() { ProductId = 4, CategoryId = 1, ProductName = "deneme2" },
                new Product() { ProductId = 5, CategoryId = 2, ProductName = "deneme3" },
                new Product() { ProductId = 6, CategoryId = 3, ProductName = "deneme4" },
                new Product() { ProductId = 7, CategoryId = 1, ProductName = "deneme5" },
                new Product() { ProductId = 8, CategoryId = 2, ProductName = "deneme6" }
            );

        }
    }

}