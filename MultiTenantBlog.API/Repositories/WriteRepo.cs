using MultiTenantBlog.API.Abstractions.Repo;
using MultiTenantBlog.API.Contexts;
using MultiTenantBlog.API.Entities;

namespace MultiTenantBlog.API.Repositories
{
    public class WriteRepo : IWriteRepo
    {
        private readonly MultiTenantBlogCtx _ctx;
        public WriteRepo(MultiTenantBlogCtx multiTenantBlogCtx)
        {
            _ctx = multiTenantBlogCtx;
        }

        public async Task CreatePost(Post post)
        {
            await _ctx.Posts.AddAsync(post);
        }
    }
}
