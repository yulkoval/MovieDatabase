using AutoMapper;
using MovieDatabase.Application.Actor.Models;
using MovieDatabase.Application.Movie.Models;
using MovieDatabase.Application.MovieToActor.Models;
using MovieDatabase.Application.Rate.Models;
using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Infrastructure
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            ConfigureMovie();
        }

        private void ConfigureMovie()
        {
            CreateMap<Movie, MovieModel>().ReverseMap();
            CreateMap<Actor, ActorModel>().ReverseMap();
            CreateMap<MovieToActor, MovieToActorModel>().ReverseMap();
            CreateMap<Rate, RateModel>().ReverseMap();

        }
    }
}
