﻿using StoreApp.UI.Infrastructe.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.ConfigureDbContext(builder.Configuration); // Extension method
builder.Services.ConfigureIdentityDbContext();
builder.Services.ConfigureSession(); // Extension method
builder.Services.ConfigureRepositoryRegistration();// Extension method
builder.Services.ConfigureServiceRegistration();// Extension method
builder.Services.CookieConfigure();
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
app.UseAuthentication();
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
    enpoints.MapControllers();
});
app.ConfigureAndCheckMigrations();
app.ConfigureLocation();
app.ConfigureDefaultAdmin();
app.Run();

