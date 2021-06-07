using System.Threading.Tasks;
using AlbumDemo.Application.Photos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace AlbumDemo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : ApiControllerBase
    {

        [HttpGet("all")]
        public async Task<ActionResult> GetPhotos([FromQuery] GetAllPhotosQuery query)
        { 
            var result = await Mediator.Send(query); 
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult> GetPhoto([FromQuery] GetPhotoByIdQuery query)
        {
            var result = await Mediator.Send(query);
            return (result != null) ? (ActionResult) Ok(result) : NotFound();
        }
    }
}