using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Rate.Models;
using MovieDatabase.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MovieDatabase.Application.Rate.Commands
{
    public record CreateRate(int Stars, int MovieId) : IRequest<RateModel>
    {
        public class Validator : AbstractValidator<CreateRate>
        {
            /// <summary>
            /// Validate entered data.
            /// </summary>
            public Validator()
            {
                RuleFor(g => g.Stars).NotEmpty().GreaterThanOrEqualTo(1).LessThanOrEqualTo(10);
                RuleFor(r => r.MovieId).NotEmpty();
            }
        }
        public class Handler : IRequestHandler<CreateRate, RateModel>
        {
            private readonly MovieDatabaseDbContext _dbContext;
            private readonly IMapper _mapper;

            public Handler(MovieDatabaseDbContext dbContext, IMapper mapper)
            {
                this._dbContext = dbContext;
                this._mapper = mapper;
            }

            /// <summary>
            /// Creates new rate record in the database for the specific movie by the movie's unique identifier and the number of stars.
            /// </summary>
            /// <param name="request">The search request.</param>
            /// <param name="cancellationToken">Propagates notification that operator should be canceled.</param>
            /// <returns>Created rate.</returns>
            public async Task<RateModel> Handle(CreateRate request,
                CancellationToken cancellationToken)
            {
                var model = new Domain.Entities.Rate { Stars = request.Stars, MovieId = request.MovieId };
                await _dbContext.Rates.AddAsync(model);
                await _dbContext.SaveChangesAsync();

                return _mapper.Map<RateModel>(model);
            }
        }
    }
}