using StoreApp.UI.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureDbContext(builder.Configuration); // Extension method
builder.Services.ConfigureSession(); // Extension method
builder.Services.ConfigureRepositoryRegistration();// Extension method
builder.Services.ConfigureServiceRegistration();// Extension method
builder.Services.ConfigureRouting();
builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();
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
app.ConfigureAndCheckMigrations();
app.ConfigureLocation();
app.Run();

