using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repo;

        public MovieService(IMovieRepository repository)
        {
            _repo = repository;
        }

        public void AddMovie(Movie movie)
        {
            _repo.Insert(movie);
            _repo.Save();
        }

        public void Edit(Movie movie)
        {
            _repo.Update(movie);
            _repo.Save();
        }

        public Movie GetMovieById(object id)
        {
            return _repo.GetById(id);
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<Movie> GetAll()
        {
            return _repo.Get();
        }

        public Movie GetMovieByTitle(string title)
        {
            return _repo.Get(m => m.Title == title).SingleOrDefault();
        }
    }
}