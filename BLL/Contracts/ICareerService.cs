using System.Collections.Generic;
using DAL.Models;

namespace BLL.Contracts
{
    public interface ICareerService
    {
        void AddCareer(Career career);
        void Edit(Career career);
        Career GetCareerById(object id);
        void Delete(object id);
        IEnumerable<Career> GetAll();
        Career GetCareerByTitle(string title);
    }
}