using System.Collections.Generic;

namespace MovieDatabase.Application.Actor.Models
{
    public class ActorListView
    {
        public IEnumerable<ActorModel> Actors { get; set; }
    }
}
