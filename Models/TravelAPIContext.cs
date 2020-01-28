using Microsoft.EntityFrameworkCore;

namespace TravelAPI.Models
{
  public class TravelAPIContext : DbContext
  {
    public TravelAPIContext(DbContextOptions<TravelAPIContext> options)
        : base(options)
    {
    }

    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Review>()
          .HasData(
              new Review { ReviewId = 1, Country = "USA", City = "Seattle", Rating = 10, ReviewDescription = "Awesome" },
              new Review { ReviewId = 2, Country = "Russia", City = "Moscow", Rating = 11, ReviewDescription = "Best" },
              new Review { ReviewId = 3, Country = "Thailand", City = "Bangkok", Rating = 8, ReviewDescription = "Good" },
              new Review { ReviewId = 4, Country = "Canada", City = "Victoria", Rating = 7, ReviewDescription = "Average" },
              new Review { ReviewId = 5, Country = "Mexico", City = "Cancun", Rating = 6, ReviewDescription = "Decent" }
          );
    }
  }
}