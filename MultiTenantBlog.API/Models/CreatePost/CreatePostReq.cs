using MediatR;

namespace MultiTenantBlog.API.Models.CreatePost
{
    public class CreatePostReq : IRequest<CreatePostRes>
    {
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
