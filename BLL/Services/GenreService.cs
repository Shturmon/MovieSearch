using System.Collections.Generic;
using System.Linq;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository _repo;

        public GenreService(IGenreRepository repository)
        {
            _repo = repository;
        }

        public void AddGenre(Genre genre)
        {
            _repo.Insert(genre);
            _repo.Save();
        }

        public void Edit(Genre genre)
        {
            _repo.Update(genre);
            _repo.Save();
        }

        public Genre GetGenreById(object id)
        {
            return _repo.GetById(id);
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<Genre> GetAll()
        {
            return _repo.Get();
        }

        public Genre GetGenreByTitle(string title)
        {
            return _repo.Get(g => g.Title == title).SingleOrDefault();
        }
    }
}