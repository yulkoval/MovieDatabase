using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MovieDatabase.Domain.Entities;

namespace MovieDatabase.Persistence.Configuration
{
    public class RateConfiguration : IEntityTypeConfiguration<Rate>
    {
        public void Configure(EntityTypeBuilder<Rate> builder)
        {
            builder.ToTable(nameof(Rate));

            builder.Property(e => e.Id)
                .HasColumnName("Id")
                .ValueGeneratedOnAdd();

            builder.HasOne(d => d.Movie)
                .WithMany(p => p.Rates)
                .HasForeignKey(d => d.MovieId)
                .HasConstraintName("FK_Rate_Movie");
        }
    }
}
