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


    }
}