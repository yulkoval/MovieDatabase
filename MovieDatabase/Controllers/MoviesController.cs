using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieDatabase.Application.Movie.Queries;
using MovieDatabase.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovieDatabase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MoviesController : MovieBaseController
    {
        public MoviesController(IMediator mediator):base(mediator)
        {
        }

        /// <summary>
        /// HTTP GET request to "api/getAllMoviesAsync".
        /// </summary>
        /// <returns>The list with movies ordered by the rate.</returns>
        [HttpGet("getAllMoviesAsync")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesAsync()
        {
            var moviesListView = await Mediator.Send(new GetAllMovies());
            return Ok(moviesListView);
        }

        /// <summary>
        /// HTTP GET request to "api/Movies/getMovieByIdAsync".
        /// </summary>
        /// <param name="movieId">Movie unique identifier.</param>
        /// <returns>MovieModel by Id.</returns>
        [HttpGet("getMovieByIdAsync")]
        [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
        public async Task<ActionResult<Movie>> GetMovieByIdAsync(int movieId)
        {
            var movie = await Mediator.Send(new GetMovieById(movieId));
            return Ok(movie);
        }

        /// <summary>
        /// HTTP GET request to "api/Movies/getMoviesByPageAsync".
        /// </summary>
        /// <param name="pageIndex">The index of the page.</param>
        /// <param name="pageSize">Required number of movies.</param>
        /// <param name="filterString">Filtering parameter.</param>
        /// <returns>The list with movies ordered by the rate for the pages  and filtered by the containing the specific key ih the title.</returns>
        [HttpGet("getMoviesByPageAsync")]
        [ProducesResponseType(typeof(IEnumerable<Movie>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMoviesByPageAsync(int pageIndex, int pageSize, string filterString)
        {
            var moviesListView = await Mediator.Send(new GetMoviesByPage(pageIndex, pageSize, filterString));
            return Ok(moviesListView);
        }
    }
}
