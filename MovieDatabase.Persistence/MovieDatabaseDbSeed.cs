using MovieDatabase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieDatabase.Persistence
{
    public class MovieDatabaseDbSeed
    {
        private readonly MovieDatabaseDbContext _movieDatabaeDbContext;
        public MovieDatabaseDbSeed(MovieDatabaseDbContext movieDatabaeDbContext)
        {
            _movieDatabaeDbContext = movieDatabaeDbContext;
        }

        public void Seed()
        {
            SeedActors();
            SeedMovies();
            SeedRates();
            SeedMovieToActors();
        }

        private void SeedActors()
        {
            List<Actor> actors = new List<Actor>
            {
                new Actor
                {
                    Name = "Vin Diesel"
                },
                new Actor
                {
                    Name = "Paul Walker"
                },
                new Actor
                {
                    Name = "Jordana Brewster"
                },
                new Actor
                {
                    Name = "Margot Robbie"
                },
                new Actor
                {
                    Name = "Jared Leto"
                },
                new Actor
                {
                    Name = "Kevin Hart"
                },
                new Actor
                {
                    Name = "Dwayne Johnson"
                },
                new Actor
                {
                    Name = "Zac Efron"
                },
                new Actor
                {
                    Name = "Jason Statham"
                }

            };

            foreach (var actor in actors)
            {
                if (!_movieDatabaeDbContext.Actors.Any(a => a.Id == actor.Id))
                {
                    _movieDatabaeDbContext.Actors.Add(actor);
                }
            }

            _movieDatabaeDbContext.SaveChanges();
        }

        private void SeedMovies()
        {
            List<Movie> movies = new List<Movie>()
            {
                new Movie
                {
                    Title = "Movie1",
                    Description = "Description 1",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie2",
                    Description = "Description 2",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie3",
                    Description = "Description 3",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie4",
                    Description = "Description 4",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie5",
                    Description = "Description 5",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie6",
                    Description = "Description 6",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie7",
                    Description = "Description 7",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie8",
                    Description = "Description 8",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie9",
                    Description = "Description 9",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie10",
                    Description = "Description 10",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie11",
                    Description = "Description 11",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie12",
                    Description = "Description 12",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie13",
                    Description = "Description 13",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie14",
                    Description = "Description 14",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                },
                new Movie
                {
                    Title = "Movie",
                    Description = "Description 15",
                    ImageName = "F1.jpg",
                    ImageBunaryData = null,
                    DateOfRease = new DateTime(2015, 12, 31, 5, 10, 20)
                }
            };

            foreach (var movie in movies)
            {
                if (!_movieDatabaeDbContext.Movies.Any(m => m.Id == movie.Id))
                {
                    _movieDatabaeDbContext.Movies.Add(movie);
                }
            }

            _movieDatabaeDbContext.SaveChanges();
        }

        private void SeedRates()
        {

            List<Rate> rates = new List<Rate>
            {
                new Rate
                {
                    Stars = 1,
                    MovieId = 1
                },
                new Rate
                {
                    Stars = 2,
                    MovieId = 1
                },
                new Rate
                {
                    Stars = 3,
                    MovieId = 1
                },
                new Rate
                {
                    Stars = 4,
                    MovieId = 1
                },
                new Rate
                {
                    Stars = 5,
                    MovieId = 5
                }
            };

            foreach (var rate in rates)
            {
                if (!_movieDatabaeDbContext.Rates.Any(r => r.Id == rate.Id))
                {
                    _movieDatabaeDbContext.Rates.Add(rate);
                }
            }

            _movieDatabaeDbContext.SaveChanges();
        }

        public void SeedMovieToActors()
        {
            List<MovieToActor> movieToActors = new List<MovieToActor>()
            {
                new MovieToActor
                {
                    MovieId = 1,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 1,
                    ActorId = 4
                },
                new MovieToActor
                {
                    MovieId = 2,
                    ActorId = 3
                },
                new MovieToActor
                {
                    MovieId = 2,
                    ActorId = 4
                },
                new MovieToActor
                {
                    MovieId = 3,
                    ActorId = 5
                },
                new MovieToActor
                {
                    MovieId = 3,
                    ActorId = 8
                },
                new MovieToActor
                {
                    MovieId = 4,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 4,
                    ActorId = 7
                },
                new MovieToActor
                {
                    MovieId = 5,
                    ActorId = 8
                },
                new MovieToActor
                {
                    MovieId = 5,
                    ActorId = 7
                },
                new MovieToActor
                {
                    MovieId = 6,
                    ActorId = 4
                },
                new MovieToActor
                {
                    MovieId = 6,
                    ActorId = 3
                },
                new MovieToActor
                {
                    MovieId = 7,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 7,
                    ActorId = 9
                },
                new MovieToActor
                {
                    MovieId = 8,
                    ActorId = 8
                },
                new MovieToActor
                {
                    MovieId = 8,
                    ActorId = 7
                },
                new MovieToActor
                {
                    MovieId = 9,
                    ActorId = 6
                },
                new MovieToActor
                {
                    MovieId = 9,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 10,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 10,
                    ActorId = 8
                },
                new MovieToActor
                {
                    MovieId = 11,
                    ActorId = 4
                },
                new MovieToActor
                {
                    MovieId = 11,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 12,
                    ActorId = 9
                },
                new MovieToActor
                {
                    MovieId = 12,
                    ActorId = 7
                },
                new MovieToActor
                {
                    MovieId = 13,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 13,
                    ActorId = 8
                },
                new MovieToActor
                {
                    MovieId = 14,
                    ActorId = 6
                },
                new MovieToActor
                {
                    MovieId = 14,
                    ActorId = 1
                },
                new MovieToActor
                {
                    MovieId = 15,
                    ActorId = 9
                },
                new MovieToActor
                {
                    MovieId = 15,
                    ActorId = 5
                },
            };

            foreach (var movieToActor in movieToActors)
            {
                if (!_movieDatabaeDbContext.MovieToActors.Any(ma => ma.Id == movieToActor.Id))
                {
                    _movieDatabaeDbContext.MovieToActors.Add(movieToActor);
                }
            }

            _movieDatabaeDbContext.SaveChanges();
        }
    }
}
