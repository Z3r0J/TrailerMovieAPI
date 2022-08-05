using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TrailerMovieAPI.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public abstract class BaseAPIController : ControllerBase
    {
    }
}
