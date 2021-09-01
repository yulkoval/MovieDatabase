using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Persistence.Configuration
{
    public class MovieToActorConfiguration : IEntityTypeConfiguration<MovieToActor>
    {
        public void Configure(EntityTypeBuilder<MovieToActor> builder)
        {
            builder.ToTable(nameof(MovieToActor));

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasOne(d => d.Actor)
                .WithMany(p => p.MovieToActors)
                .HasForeignKey(d => d.ActorId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MovieToActor_Actor");

            builder.HasOne(d => d.Movie)
                .WithMany(p => p.MovieToActors)
                .HasForeignKey(d => d.MovieId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MovieToActor_Movie");
        }
    }
}
