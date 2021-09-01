using MovieDatabase.Domain.Entities;
using MovieDatabase.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Services
{
    public class MovieDatabaseService : IMovieDatabaseService
    {
        public void DeleteMovie(string title)
        {
            throw new NotImplementedException();
        }

        public Task<Movie> GetMovieAsync(string title)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Movie>> GetMoviesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
