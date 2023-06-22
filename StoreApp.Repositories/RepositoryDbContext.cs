using StoreApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
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
        }
    }

}