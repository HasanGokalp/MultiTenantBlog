using Microsoft.EntityFrameworkCore;
using MultiTenantBlog.API.Abstractions.Entity;
using MultiTenantBlog.API.Abstractions.Service;
using MultiTenantBlog.API.Entities;

namespace MultiTenantBlog.API.Contexts
{
    public class MultiTenantBlogCtx : DbContext
    {
        public DbSet<Post> Posts { get; set; }

        private readonly ITentantService _tentantService;
        private string TentantId;

        public MultiTenantBlogCtx(DbContextOptions options, ITentantService tentantService) : base(options)
        {
            _tentantService = tentantService;
            TentantId = _tentantService.GetTenant()?.TentantId;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasQueryFilter(p => p.TenantId == TentantId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_tentantService.GetConnectionString());
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                    case EntityState.Modified:
                        entry.Entity.TenantId = TentantId;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
