using MovieDatabase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieDatabase.Services.Interfaces
{
    public interface IMovieDatabaseService
    {
        Task<IEnumerable<Movie>> GetMoviesAsync();
        Task<Movie> GetMovieAsync(string title);
        void DeleteMovie(string title);
    }
}
