using System.Collections.Generic;
using System.Linq;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class CountryService : ICountryService
    {
        private ICountryRepository _repo;

        public CountryService(ICountryRepository repository)
        {
            _repo = repository;
        }

        public void AddCountry(Country country)
        {
            _repo.Insert(country);
            _repo.Save();
        }

        public void Edit(Country country)
        {
            _repo.Update(country);
            _repo.Save();
        }

        public Country GetCountryById(object id)
        {
            return _repo.GetById(id);
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<Country> GetAll()
        {
            return _repo.Get();
        }

        public Country GetCountryByTitle(string title)
        {
            return _repo.Get(c => c.Title == title).SingleOrDefault();
        }
    }
}