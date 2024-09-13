using MediatR;

namespace MultiTenantBlog.API.Models.CreatePost
{
    public class CreatePostReq : IRequest<CreatePostRes>
    {
    }
}
