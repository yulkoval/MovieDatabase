using AutoMapper;
using FluentValidation;
using MediatR;
using MovieDatabase.Application.Movie.Models;
using MovieDatabase.Persistence;
using System.Linq;
using MovieDatabase.Application.Validation.ValidationExceptions;
using System.Threading;
using System.Threading.Tasks;

namespace MovieDatabase.Application.Movie.Queries
{
    public record GetMovieById(int MovieId) : IRequest<MovieModel>
    {
        public class Validator : AbstractValidator<GetMovieById>
        {
            /// <summary>
            /// Validate entered data.
            /// </summary>
            public Validator()
            {
                RuleFor(r => r.MovieId).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<GetMovieById, MovieModel>
        {
            private readonly MovieDatabaseDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(MovieDatabaseDbContext dbContext, IMapper mapper)
            {
                this._dbContext = dbContext;
                this._mapper = mapper;
            }


            /// <summary>
            /// Returns the movie with the specific unique identifier.
            /// </summary>
            /// <param name="request">The search request.</param>
            /// <param name="cancellationToken">Propagates notification that operator should be canceled.</param>
            /// <returns>The movie with the specific unique identifier.</returns>
            public async Task<MovieModel> Handle(GetMovieById request,
                CancellationToken cancellationToken)
            {
                var res = _dbContext.Movies
                    .FirstOrDefault(r => r.Id == request.MovieId);

                if (res == null)
                {
                    throw new NotFoundException(nameof(Domain.Entities.Movie), request.MovieId);
                }

                return _mapper.Map<MovieModel>(res);
            }
        }
    }
}
