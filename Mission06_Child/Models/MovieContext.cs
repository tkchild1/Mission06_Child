using Microsoft.EntityFrameworkCore;

namespace Mission06_Child.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
            : base(options)
        {
        }
        // Movies table
        public DbSet<Movie> Movies { get; set; }
        // Categories table
        public DbSet<Category> Categories { get; set; }
        // Configure relationships between tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Set up foreign key relationship between Movies and Categories
            modelBuilder.Entity<Movie>()
                .HasOne(m => m.Category)
                .WithMany(c => c.Movies)
                .HasForeignKey(m => m.CategoryId);
        }
    }
}
