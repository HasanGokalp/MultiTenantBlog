using Microsoft.EntityFrameworkCore;
using MultiTenantBlog.API.ConfClasses;
using MultiTenantBlog.API.Contexts;

namespace MultiTenantBlog.API.Registration
{
    public static class ServiceRegistration
    {
        public static async Task AddPersistenceService(this IServiceCollection collection)
        {
            using var provider = collection.BuildServiceProvider();
            var configuration = provider.GetRequiredService<IConfiguration>();
            var tenantSettings = configuration.GetSection("TentantSettings").Get<TentantSettings>();

            var defaultConnectionString = tenantSettings.Defaults?.ConnectionString;
       
                collection.AddDbContext<MultiTenantBlogCtx>(option => option.UseSqlServer(e => e.MigrationsAssembly(typeof(MultiTenantBlogCtx).Assembly.FullName)));

            using IServiceScope scope = collection.BuildServiceProvider().CreateScope();

            foreach (var tenant in tenantSettings.Tentants)
            {
                string connectionString = tenant.ConnectionString switch
                {
                    null => defaultConnectionString,
                    not null => tenant.ConnectionString
                };
                var dbContext = scope.ServiceProvider.GetRequiredService<MultiTenantBlogCtx>();
                dbContext.Database.SetConnectionString(connectionString);
                if (dbContext.Database.GetMigrations().Count() > 0)
                    await dbContext.Database.MigrateAsync();
            }
        }
    }
}
