using System;
using System.Collections.Generic;
using DAL.Models;

namespace BLL.Contracts
{
    public interface IPeopleService
    {
        void AddPeople(People people);
        void Edit(People people);
        People GetPeopleById(object id);
        void Delete(object id);
        IEnumerable<People> GetAll();
        IEnumerable<People> GetPeoplesByFullName(string firstName, string lastName);

        Guid GetDirectorIdForMovie(Movie movie);
    }
}