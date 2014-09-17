using System.Collections.Generic;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class CastAndCrewService : ICastAndCrewService
    {
        private ICastAndCrewRepository _repo;

        public CastAndCrewService(ICastAndCrewRepository repository)
        {
            _repo = repository;
        }

        public void AddCastAndCrew(CastAndCrew castAndCrew)
        {
            _repo.Insert(castAndCrew);
            _repo.Save();
        }

        public void Edit(CastAndCrew castAndCrew)
        {
            _repo.Update(castAndCrew);
            _repo.Save();
        }

        public CastAndCrew GetCastAndCrewById(object id)
        {
            return _repo.GetById(id);
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<CastAndCrew> GetAll()
        {
            return _repo.Get();
        }
    }
}