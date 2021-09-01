using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Rate.Commands;
using MovieDatabase.Domain.Entities;
using System.Threading.Tasks;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatesController : MovieBaseController
    {
        public RatesController(IMediator mediator) : base(mediator)
        {

        }

        /// <summary>
        /// HTTP POST request to "api/Rates".
        /// </summary>
        /// <param name="stars">Nuber of stars.</param>
        /// <param name="movieId">The unique identifier of the Movie.</param>
        /// <returns>Created rate.</returns>
        // POST: api/Rates
        [HttpPost]
        [ProducesResponseType(typeof(Rate), StatusCodes.Status200OK)]
        public async Task<ActionResult<Rate>> CreateRateAsync(int stars, int movieId)
        {
            var rate = await Mediator.Send(new CreateRate(stars, movieId));
            return Ok(rate);
        }        
    }
}