using MultiTenantBlog.API.Entities;

namespace MultiTenantBlog.API.Abstractions.Repo
{
    public interface IReadRepo
    {
        Task<IList<Post>> GetAllAsync();
    }
}
