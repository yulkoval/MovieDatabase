using System.Collections.Generic;

namespace MovieDatabase.Application.MovieToActor.Models
{
    public class MovieToActorsListView
    {
        public IEnumerable<MovieToActorModel> MovieToActors { get; set; }
    }
}
