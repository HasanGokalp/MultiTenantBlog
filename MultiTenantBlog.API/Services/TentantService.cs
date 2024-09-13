using Microsoft.Extensions.Options;
using MultiTenantBlog.API.Abstractions.Service;
using MultiTenantBlog.API.ConfClasses;

namespace MultiTenantBlog.API.Services
{
    public class TentantService : ITentantService
    {
        readonly TentantSettings _settings;
        readonly Tentant _tenant;
        readonly HttpContext _httpContext;

        public TentantService(IOptions<TentantSettings> options, IHttpContextAccessor httpContextAccessor)
        {
            _settings = options.Value;
            _httpContext = httpContextAccessor.HttpContext;

            if (_httpContext != null)
            {
                if (_httpContext.Request.Headers.TryGetValue("TenantId", out var tenantId))
                {
                    _tenant = _settings.Tentants.FirstOrDefault(t => t.TentantId == tenantId);
                    if (_tenant == null) throw new Exception("Invalid tenant!");

                    //Eğer bu kullanıcı grubu/müşteri/kiracı paylaşımlı veritabanını kullanıyorsa connection string'i boş gelecektir.
                    if (string.IsNullOrEmpty(_tenant.ConnectionString))
                        _tenant.ConnectionString = _settings.Defaults.ConnectionString;
                }
            }
        }

        public string GetConnectionString()
        {
            return _tenant?.ConnectionString;
        }

        public string GetDatabaseProvider()
        {
            throw new NotImplementedException();
        }

        public Tentant GetTenant()
        {
            return _tenant;
        }
    }
}
