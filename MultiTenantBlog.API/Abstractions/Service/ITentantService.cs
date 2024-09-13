using MultiTenantBlog.API.ConfClasses;

namespace MultiTenantBlog.API.Abstractions.Service
{
    public interface ITentantService
    {
        string GetDatabaseProvider();
        string GetConnectionString();
        Tentant GetTenant();
    }
}
