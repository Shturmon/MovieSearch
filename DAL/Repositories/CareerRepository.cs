using System.Linq;
using BLL;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories
{
    public class CareerRepository : BaseRepository<Career>, ICareerRepository
    {
        public CareerRepository(MoviesContext context)
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