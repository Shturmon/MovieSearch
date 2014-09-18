using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Context
{
    public class MoviesDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CastAndCrew> CastAndCrews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserComment> UserComments { get; set; }

        public MoviesDbContext()
            : base("MoviesContext")
        {
            Database.SetInitializer(new ApplicationDbInitializer());
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MoviesContext>());
        }

        public static MoviesDbContext Create()
        {
            return new MoviesDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Movie>()
                        .Property(f => f.PremiereDate)
                        .HasColumnType("datetime2");
        }
    }
}