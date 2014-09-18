using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Logic.Contracts.Services
{
    public interface ICastAndCrewService
    {
        void AddCastAndCrew(CastAndCrew castAndCrew);
        void Edit(CastAndCrew castAndCrew);
        CastAndCrew GetCastAndCrewById(object id);
        void Delete(object id);
        IEnumerable<CastAndCrew> GetAll();
    }
}