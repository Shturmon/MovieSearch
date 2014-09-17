using System.Collections.Generic;
using System.Linq;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class CareerService : ICareerService
    {
        private ICareerRepository _repo;

        public CareerService(ICareerRepository repository)
        {
            _repo = repository;
        }

        public void AddCareer(Career career)
        {
            _repo.Insert(career);
            _repo.Save();
        }

        public void Edit(Career career)
        {
            _repo.Update(career);
            _repo.Save();
        }

        public Career GetCareerById(object id)
        {
            return _repo.GetById(id);
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<Career> GetAll()
        {
            return _repo.Get();
        }

        public Career GetCareerByTitle(string title)
        {
            return _repo.Get(c => c.Title == title).SingleOrDefault();
        }
    }
}