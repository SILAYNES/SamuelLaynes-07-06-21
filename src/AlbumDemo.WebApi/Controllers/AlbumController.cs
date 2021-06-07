using System.Threading.Tasks;
using AlbumDemo.Application.Albums.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AlbumDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ApiControllerBase
    {

        [HttpGet("all")]
        public async Task<ActionResult> GetAlbum()
        { 
            var result = await Mediator.Send(new GetAllAlbumsQuery()); 
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetAlbum([FromQuery] GetAlbumByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return (result != null) ? (ActionResult) Ok(result) : NotFound();
        }
    }
}