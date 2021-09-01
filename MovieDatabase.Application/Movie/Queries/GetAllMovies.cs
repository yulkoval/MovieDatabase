using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Movie.Models;
using MovieDatabase.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieDatabase.Application.Movie.Queries
{
    public record GetAllMovies : IRequest<MoviesListView>
    {
        public class Handler : IRequestHandler<GetAllMovies, MoviesListView>
        {
            private readonly MovieDatabaseDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(MovieDatabaseDbContext dbContext, IMapper mapper)
            {
                this._dbContext = dbContext;
                this._mapper = mapper;
            }

            /// <summary>
            /// Returns the list of movies ordered by the rate.
            /// </summary>
            /// <param name="request">The search request.</param>
            /// <param name="cancellationToken">Propagates notification that operator should be canceled.</param>
            /// <returns>ActorListView which contains the list of movies ordered by the rate.</returns>
            public async Task<MoviesListView> Handle(GetAllMovies request,
                CancellationToken cancellationToken)
            {
                var res = await _dbContext.Movies
                   .Include(x => x.MovieToActors)
                   .ThenInclude(y => y.Actor)
                   .Include(r => r.Rates)
                   .AsNoTracking()
                   .Select(it => _mapper.Map<MovieModel>(it))
                   .ToListAsync();

                var orderedResult = res.Select(it =>
                {
                    it.AverageRate = it.Rates.Any() ? it.Rates.Average(i => i.Stars) : 0;
                    return it;
                })
                    .OrderByDescending(x => x.AverageRate)
                    .ToList();

                return new MoviesListView { Movies = orderedResult };
            }
        }
    }
}
