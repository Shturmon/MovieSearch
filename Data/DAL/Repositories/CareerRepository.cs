using System.Linq;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Repositories
{
    public class CareerRepository : BaseRepository<Career>, ICareerRepository
    {
        public CareerRepository(MoviesDbContext context)
            : base(context)
        {
        }

        public Career GetByTitle(string title)
        {
            return Context.Careers.FirstOrDefault((c => c.Title == title));
        }

        public override void Insert(Career career)
        {
            if (career == null)
                return;

            var dbCareer = GetByTitle(career.Title);
            if (dbCareer == null)
                DbSet.Add(career);
        }
    }
}