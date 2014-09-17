using System.Collections.Generic;
using DAL.Models;

namespace BLL.Contracts
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