using MediatR;

namespace MultiTenantBlog.API.Models.GetAllPost
{
    public class GetAllPostReq : IRequest<IList<GetAllPostRes>>
    {

    }

}
