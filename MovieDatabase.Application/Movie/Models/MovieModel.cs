using MovieDatabase.Application.MovieToActor.Models;
using MovieDatabase.Application.Rate.Models;
using System;
using System.Collections.Generic;

namespace MovieDatabase.Application.Movie.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public byte[] ImageBunaryData { get; set; }
        public DateTime DateOfRease { get; set; }
        public double AverageRate { get; set; }
        public IEnumerable<RateModel> Rates { get; set; }
        public IEnumerable<MovieToActorModel> MovieToActors { get; set; }
    }
}
