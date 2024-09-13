using Microsoft.EntityFrameworkCore;
using MultiTenantBlog.API.Abstractions.Repo;
using MultiTenantBlog.API.Contexts;
using MultiTenantBlog.API.Entities;
using System.Runtime.InteropServices;

namespace MultiTenantBlog.API.Repositories
{
    public class ReadRepo : IReadRepo
    {
        private readonly MultiTenantBlogCtx _ctx;
        public ReadRepo(MultiTenantBlogCtx multiTenantBlogCtx)
        {
            _ctx = multiTenantBlogCtx;
        }

        public async Task<IList<Post>> GetAllAsync()
        {
            return await _ctx.Posts.ToListAsync();
        }
    }
}
