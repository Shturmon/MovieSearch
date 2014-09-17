using System.Data.Entity;
using DAL.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DAL
{
    public class MoviesContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Career> Careers { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<CastAndCrew> CastAndCrews { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<UserComment> UserComments { get; set; }

        public MoviesContext()
            : base("MoviesContext")
        {
            Database.SetInitializer(new ApplicationDbInitializer(/*this*/));
            //Database.SetInitializer(new CreateDatabaseIfNotExists<MoviesContext>());
        }

        public static MoviesContext Create()
        {
            return new MoviesContext();
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