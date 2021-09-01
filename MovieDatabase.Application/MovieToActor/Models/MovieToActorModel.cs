using MovieDatabase.Application.Actor.Models;

namespace MovieDatabase.Application.MovieToActor.Models
{
    public class MovieToActorModel
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public int ActorId { get; set; }
        public ActorModel Actor { get; set; }
    }
}
