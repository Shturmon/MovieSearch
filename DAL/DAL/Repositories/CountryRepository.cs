using System.Linq;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(MoviesDbContext context)
            : base(context)
        {
        }

        public Country GetByTitle(string title)
        {
            return Context.Countries.FirstOrDefault((c => c.Title == title));
        }

        public override void Insert(Country country)
        {
            if (country == null)
                return;

            var dbCountry = GetByTitle(country.Title);
            if (dbCountry == null)
                DbSet.Add(country);
        }
    }
}