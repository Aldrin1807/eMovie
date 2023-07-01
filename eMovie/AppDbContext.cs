using eMovie.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eMovie
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(a => new
            {
                a.MovieId,
                a.ActorId
            });
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(a => a.Movie)
                .WithMany(a => a.Actors_Movies)
                .HasForeignKey(a => a.MovieId);
            modelBuilder.Entity<Actor_Movie>()
                .HasOne(a => a.Actor)
                .WithMany(a => a.Actors_Movies)
                .HasForeignKey(a => a.ActorId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set;}
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
