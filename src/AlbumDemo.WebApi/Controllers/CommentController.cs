using System.Threading.Tasks;
using AlbumDemo.Application.Comments.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AlbumDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ApiControllerBase
    {

        [HttpGet("all")]
        public async Task<ActionResult> GetComments([FromQuery] GetAllCommentsQuery query)
        { 
            var result = await Mediator.Send(query); 
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetComment([FromQuery] GetCommentByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return (result != null) ? (ActionResult) Ok(result) : NotFound();
        }
    }
}