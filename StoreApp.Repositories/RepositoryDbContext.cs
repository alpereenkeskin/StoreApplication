using StoreApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>().HasData(
                new Product() { ProductId = 4, ProductName = "deneme2" },
                new Product() { ProductId = 5, ProductName = "deneme3" },
                new Product() { ProductId = 6, ProductName = "deneme4" },
                new Product() { ProductId = 7, ProductName = "deneme5" },
                new Product() { ProductId = 8, ProductName = "deneme6" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { CategoryId = 1, CategoryName = "Deneme Kategori" },
                new Category() { CategoryId = 2, CategoryName = "Deneme Kategori 2" },
                new Category() { CategoryId = 3, CategoryName = "Deneme Kategori 3" },
                new Category() { CategoryId = 4, CategoryName = "Deneme Kategori 4" }
            );
        }
    }

}