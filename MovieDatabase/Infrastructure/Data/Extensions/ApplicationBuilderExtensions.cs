using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieDatabase.Persistence;
using System.Linq;

namespace MovieDatabase.Infrastructure.Data.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MovieDatabaseDbContext>();

                var seedService = serviceScope.ServiceProvider.GetService<MovieDatabaseDbSeed>();
                if (!context.Movies.Any()) //Dummy check
                {
                    seedService.Seed();
                }
            }
            return app;
        }

        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<MovieDatabaseDbContext>();
                context.Database.Migrate();
            }
            return app;
        }
    }
}
