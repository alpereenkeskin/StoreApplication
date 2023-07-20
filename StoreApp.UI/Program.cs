using Microsoft.EntityFrameworkCore;
using StoreApp.Entites;
using StoreApp.Repositories;
using StoreApp.Repositories.Concrete;
using StoreApp.Services;
using StoreApp.Services.Concrete;
using StoreApp.UI.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RepositoryDbContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("StoreApp.UI"));
});
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddScoped<IOrderService, OrderManager>();
builder.Services.AddScoped<Cart>(c => SessionCart.GetCart(c));
builder.Services.AddAutoMapper(typeof(Program));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();
app.UseSession();
app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(enpoints =>
{
    enpoints.MapAreaControllerRoute(
        name: "Admin", areaName: "Admin", pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
    );
    enpoints.MapControllerRoute(
        name: "default", pattern: "{controller=Home}/{action=Index}/{id?}"
        );
    enpoints.MapRazorPages();
});

app.Run();

