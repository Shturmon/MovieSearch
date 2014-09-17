using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class PeopleService : IPeopleService
    {
        private IPeopleRepository _repo;

        public PeopleService(IPeopleRepository repository)
        {
            _repo = repository;
        }

        public void AddPeople(People people)
        {
            _repo.Insert(people);
            _repo.Save();
        }

        public void Edit(People people)
        {
            _repo.Update(people);
            _repo.Save();
        }

        public People GetPeopleById(object id)
        {
            return _repo.GetById(id);
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<People> GetAll()
        {
            return _repo.Get();
        }

        public IEnumerable<People> GetPeoplesByFullName(string firstName, string lastName)
        {
            return _repo.Get(p => p.FirstName == firstName && p.LastName == lastName);
        }

        public Guid GetDirectorIdForMovie(Movie movie)
        {
            return _repo.GetDirectorIdForMovie(movie);
        }
    }
}