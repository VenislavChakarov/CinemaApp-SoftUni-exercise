using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration;

public class UserMovieConfiguration : IEntityTypeConfiguration<UserMovie>
{
    public void Configure(EntityTypeBuilder<UserMovie> entity)
    {
        entity.HasKey(um => new { um.UserId, um.MovieId });

        entity.HasOne(um => um.User)
            .WithMany()
            .HasForeignKey(um => um.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        entity.HasOne(um => um.Movie)
            .WithMany()
            .HasForeignKey(um => um.MovieId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}