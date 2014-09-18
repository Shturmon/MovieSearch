using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Logic.Contracts.Services
{
    public interface IGenreService
    {
        void AddGenre(Genre genre);
        void Edit(Genre genre);
        Genre GetGenreById(object id);
        void Delete(object id);
        IEnumerable<Genre> GetAll();
        Genre GetGenreByTitle(string title);
    }
}