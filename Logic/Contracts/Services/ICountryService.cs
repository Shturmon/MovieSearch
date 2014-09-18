using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Logic.Contracts.Services
{
    public interface ICountryService
    {
        void AddCountry(Country country);
        void Edit(Country country);
        Country GetCountryById(object id);
        void Delete(object id);
        IEnumerable<Country> GetAll();
        Country GetCountryByTitle(string title);
    }
}
