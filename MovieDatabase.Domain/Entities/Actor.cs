using System.Collections.Generic;

namespace MovieDatabase.Domain.Entities
{
    public class Actor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<MovieToActor> MovieToActors { get; set; }
    }
}
