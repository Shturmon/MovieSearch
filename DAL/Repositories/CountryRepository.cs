using System;
using System.Linq;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(MoviesContext context)
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