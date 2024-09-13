using MediatR;
using MultiTenantBlog.API.Abstractions.Repo;
using MultiTenantBlog.API.Models.GetAllPost;

namespace MultiTenantBlog.API.Features.GetAllPost
{
    public class GetAllPostHandler : IRequestHandler<GetAllPostReq, IList<GetAllPostRes>>
    {
        private readonly IReadRepo _readRepo;
        public GetAllPostHandler(IReadRepo readRepo)
        {
            _readRepo = readRepo;
        }

        public async Task<IList<GetAllPostRes>> Handle(GetAllPostReq request, CancellationToken cancellationToken)
        {
            var entities = await _readRepo.GetAllAsync();
            return entities.Select(e => new GetAllPostRes
            {
                Title = e.Title,
                Content = e.Content
            }).ToList();
        }
    }
}
