using System;
using System.Collections.Generic;

namespace MovieDatabase.Domain.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageBunaryData { get; set; }
        public DateTime DateOfRease { get; set; }
        public virtual ICollection<Rate> Rates { get; set; }
        public virtual ICollection<MovieToActor> MovieToActors { get; set; }
    }
}
