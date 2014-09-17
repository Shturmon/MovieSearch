using System.Collections.Generic;
using DAL.Models;

namespace BLL.Contracts
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