using Microsoft.EntityFrameworkCore;
using MovieDatabase.Domain.Entities;
using MovieDatabase.Persistence.Configuration;

namespace MovieDatabase.Persistence
{
    public class MovieDatabaseDbContext : DbContext
    {
        public MovieDatabaseDbContext()
        {
        }
        public MovieDatabaseDbContext(DbContextOptions<MovieDatabaseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new MovieConfiguration());
            modelBuilder.ApplyConfiguration(new ActorConfiguration());
            modelBuilder.ApplyConfiguration(new RateConfiguration());
            modelBuilder.ApplyConfiguration(new LogConfiguration());
            modelBuilder.ApplyConfiguration(new MovieToActorConfiguration());
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MovieToActor> MovieToActors { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<Log> Logs { get; set; }

    }
}
