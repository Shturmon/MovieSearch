using System;
using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Logic.Contracts.Services
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