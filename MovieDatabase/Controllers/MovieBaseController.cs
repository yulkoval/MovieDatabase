using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Infrastructure.ExceptionHandling;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ExceptionResult), StatusCodes.Status500InternalServerError)]
    public abstract class MovieBaseController : ControllerBase
    {
        protected MediatR.IMediator Mediator { get; }
        protected MovieBaseController(MediatR.IMediator mediator) => Mediator = mediator;

    }
}
