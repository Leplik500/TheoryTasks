using Microsoft.EntityFrameworkCore;
using Task5.Models;

namespace Task5.Data;

public class AnimePortalContext(
                DbContextOptions<AnimePortalContext> options)
                : DbContext(options)
{
        public DbSet<Anime> Anime { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Review> Reviews { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Anime>()
                .Property(a => a.Duration)
                .HasPrecision(5, 2);

        modelBuilder.Entity<Anime>()
                .Property(a => a.AverageRating)
                .HasPrecision(3, 2);

        modelBuilder.Entity<Review>()
                .Property(r => r.Rating)
                .HasPrecision(3, 2);

        modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();
        
        base.OnModelCreating(modelBuilder);
    }
}