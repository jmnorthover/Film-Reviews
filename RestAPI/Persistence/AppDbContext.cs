using Microsoft.EntityFrameworkCore;
using RestAPI.Domain.Models;

namespace RestAPI.Persistence
{
    public class AppDbContext : DbContext
    {
        public DbSet<Review> Reviews { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Review>().ToTable("Reviews");
            builder.Entity<Review>().HasKey(r => r.ReviewId);
            builder.Entity<Review>().Property(r => r.ReviewId).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<Review>().Property(r => r.MovieId).IsRequired();
            builder.Entity<Review>().Property(r => r.Rating).IsRequired();
            builder.Entity<Review>().Property(r => r.Description).IsRequired();
        }
    }
}
