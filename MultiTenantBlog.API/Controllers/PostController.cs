using MediatR;
using Microsoft.AspNetCore.Mvc;
using MultiTenantBlog.API.Models.CreatePost;
using MultiTenantBlog.API.Models.GetAllPost;

namespace MultiTenantBlog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : Controller
    {
        private readonly IMediator _mediator;

        public PostController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPost()
        {
            var result = await _mediator.Send(new GetAllPostReq());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost(CreatePostReq createPostReq)
        {
            var result = await _mediator.Send(createPostReq);
            return Ok(result);
        }
    }
}
