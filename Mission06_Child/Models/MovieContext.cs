using Microsoft.EntityFrameworkCore;

namespace Mission06_Child.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Don't seed anything - the database already has the data!

            // Just configure the relationship
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CategoryId);
        }
    }
}
