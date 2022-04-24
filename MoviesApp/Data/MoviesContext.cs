using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public class MoviesContext : IdentityDbContext<ApplicationUser>
    {
        public MoviesContext (DbContextOptions<MoviesContext> options)
            : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<MoviesActors> MoviesActors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MoviesActors>(entity =>
            {
                entity.HasKey(sc => new { sc.MovieId, sc.ActorId });
                entity.Property(e => e.MovieId).HasColumnName("MovieID");
                entity.Property(e => e.ActorId).HasColumnName("ActorID");

                entity.HasOne(sc => sc.Movie)
                    .WithMany(p => p.Actors)
                    .HasForeignKey(sc => sc.MovieId)
                    .OnDelete(DeleteBehavior.NoAction)
                    .HasConstraintName("FK_MoviesActors_Movies");

                entity.HasOne(sc => sc.Actor)
                .WithMany(p => p.Movies)
                .HasForeignKey(sc => sc.ActorId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("FK_MoviesActors_Actors");
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}