using MovieDatabase.Application.Movie.Models;

namespace MovieDatabase.Application.Rate.Models
{
    public class RateModel
    {
        public int Id { get; set; }
        public int Stars { get; set; }
        public int MovieId { get; set; }
        public MovieModel Movie { get; set; }
    }
}
