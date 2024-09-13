using MultiTenantBlog.API.Entities;

namespace MultiTenantBlog.API.Abstractions.Repo
{
    public interface IWriteRepo
    {
        Task CreatePost(Post post);
    }
}
