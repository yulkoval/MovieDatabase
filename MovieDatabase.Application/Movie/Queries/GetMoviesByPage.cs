using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Movie.Models;
using MovieDatabase.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieDatabase.Application.Movie.Queries
{
    public record GetMoviesByPage(int PageIndex, int PageSize, string FilterString) : IRequest<MoviesListView>
    {
        public class Validator : AbstractValidator<GetMoviesByPage>
        {
            /// <summary>
            /// Validate entered data.
            /// </summary>
            public Validator()
            {
                RuleFor(r => r.PageIndex).NotEmpty();
                RuleFor(r => r.PageSize).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<GetMoviesByPage, MoviesListView>
        {
            private readonly MovieDatabaseDbContext _dbContext;
            private readonly IMapper _mapper;
            public Handler(MovieDatabaseDbContext dbContext, IMapper mapper)
            {
                this._dbContext = dbContext;
                this._mapper = mapper;
            }

            /// <summary>
            /// Returns the list of movies ordered by the rate for the specific page, skips entered number of movies and filters movie's title by the containing the specific key.
            /// </summary>
            /// <param name="request">The search request.</param>
            /// <param name="cancellationToken">Propagates notification that operator should be canceled.</param>
            /// <returns>MoviesListView which contains the list of movies ordered by the rate for the specific page and filtered by the containing the specific key ih the title.</returns>
            public async Task<MoviesListView> Handle(GetMoviesByPage request,
                CancellationToken cancellationToken)
            {
                var res = await _dbContext.Movies
                    .Include(x => x.MovieToActors)
                    .ThenInclude(y => y.Actor)
                    .Include(r=>r.Rates)
                    .AsNoTracking()
                    .Select(it => _mapper.Map<MovieModel>(it))
                    .Skip((request.PageIndex-1)*request.PageSize)
                    .Take(request.PageSize)
                    .ToListAsync();

                var filteredRes = res
                    .Where(i => i.Title.Contains(request.FilterString)).ToList();


                var orderedResult = filteredRes.Select(it =>
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
