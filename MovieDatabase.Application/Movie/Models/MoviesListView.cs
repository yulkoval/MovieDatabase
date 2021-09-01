using System.Collections.Generic;

namespace MovieDatabase.Application.Movie.Models
{
    public class MoviesListView
    {
        public IEnumerable<MovieModel> Movies { get; set; }
    }
}
