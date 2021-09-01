using MovieDatabase.Application.MovieToActor.Models;
using System.Collections.Generic;

namespace MovieDatabase.Application.Actor.Models
{
    public class ActorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<MovieToActorModel> MovieToActors { get; set; }
    }
}
