using StoreApp.Entites;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Repositories
{
    public class RepositoryDbContext : DbContext
    {
        public DbSet<Product>? Products { get; set; }
        public DbSet<Category>? Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
        }
    }

}