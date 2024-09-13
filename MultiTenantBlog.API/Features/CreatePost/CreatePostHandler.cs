using MediatR;
using MultiTenantBlog.API.Abstractions.Repo;
using MultiTenantBlog.API.Entities;
using MultiTenantBlog.API.Models.CreatePost;

namespace MultiTenantBlog.API.Features.CreatePost
{
    public class CreatePostHandler : IRequestHandler<CreatePostReq, CreatePostRes>
    {
        private readonly IWriteRepo _writeRepo;

        public CreatePostHandler(IWriteRepo writeRepo)
        {
            _writeRepo = writeRepo;
        }
        public async Task<CreatePostRes> Handle(CreatePostReq request, CancellationToken cancellationToken)
        {
            var entity = new Post
            {
                Id = 1,
                Title = "Title",
                Content = "Content"
            };
            await _writeRepo.CreatePost(entity);
            return new CreatePostRes
            {
                IsIt = true
            };
        }
    }
}
