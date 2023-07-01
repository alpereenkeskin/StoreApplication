using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StoreApp.Entites;

namespace StoreApp.Repositories
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.CategoryId);
            builder.Property(x => x.CategoryName).IsRequired();
            builder.HasData(
                 new Category() { CategoryId = 1, CategoryName = "Deneme Kategori" },
                 new Category() { CategoryId = 2, CategoryName = "Deneme Kategori 2" },
                 new Category() { CategoryId = 3, CategoryName = "Deneme Kategori 3" },
                 new Category() { CategoryId = 4, CategoryName = "Deneme Kategori 4" }
            );
        }
    }

}