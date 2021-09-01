using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MovieDatabase.Application.Rate.Models;
using MovieDatabase.Persistence;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MovieDatabase.Application.Rate.Queries
{
    public record GetAllRates : IRequest<RatesListView>
    {
        public class Handler : IRequestHandler<GetAllRates, RatesListView>
        {
            private readonly MovieDatabaseDbContext _dbContext;
            private readonly IMapper mapper;

            public Handler(MovieDatabaseDbContext dbContext, IMapper mapper)
            {
                this._dbContext = dbContext;
                this.mapper = mapper;
            }

            /// <summary>
            /// Returns the list of rates.
            /// </summary>
            /// <param name="request">The search request.</param>
            /// <param name="cancellationToken">Propagates notification that operator should be canceled.</param>
            /// <returns>RatesListView which contains the list of rates.</returns>
            public async Task<RatesListView> Handle(GetAllRates request,
                CancellationToken cancellationToken)
            {
                var res = await _dbContext.Movies
                        .AsNoTracking()
                        .Select(it => mapper.Map<RateModel>(it)
                        ).ToListAsync();

                return new RatesListView { Rates = res };
            }
        }
    }
}
