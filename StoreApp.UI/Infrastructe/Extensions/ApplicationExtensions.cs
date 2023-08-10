using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StoreApp.Repositories;

namespace StoreApp.UI.Infrastructe.Extensions
{
    public static class ApplicationExtensions
    {
        public static void ConfigureAndCheckMigrations(this IApplicationBuilder app)
        {
            RepositoryDbContext context = app.ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RepositoryDbContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
        }
        public static void ConfigureLocation(this WebApplication app)
        {
            app.UseRequestLocalization(options =>
            {
                options.AddSupportedCultures("tr-TR")
                .AddSupportedUICultures("tr-TR")
                .SetDefaultCulture("tr-TR");// bu ifadeler birden fazla string ülke kodu alabilir.
            });

        }
        public static async void ConfigureDefaultAdmin(this IApplicationBuilder app)
        {
            const string adminName = "Admin";
            const string adminPassword = "Admin1234.";

            UserManager<IdentityUser> userManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<UserManager<IdentityUser>>();

            RoleManager<IdentityRole> roleManager = app
            .ApplicationServices
            .CreateScope()
            .ServiceProvider
            .GetRequiredService<RoleManager<IdentityRole>>();

            IdentityUser adminuser = await userManager.FindByNameAsync(adminName);
            if (adminuser == null)
            {
                adminuser = new IdentityUser()
                {
                    UserName = adminName,
                    PhoneNumber = "5555555555",
                    Email = "alperen@info.com",
                };
                var result = await userManager.CreateAsync(adminuser, adminPassword);
                if (!result.Succeeded)
                {
                    throw new Exception("admin user could not created");
                }
                var roleResult = await userManager.AddToRolesAsync(adminuser,
                    roleManager
                    .Roles
                    .Select(r => r.Name)
                    .ToList()
                );
                if (!roleResult.Succeeded)
                {
                    throw new Exception($"Failed to add role to {adminuser}.");
                }
            }


        }


    }
}