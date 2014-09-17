using System;
using System.Collections;
using System.Collections.Generic;
using DAL.Models;

namespace BLL.Contracts
{
    public interface IMovieService
    {
        void AddMovie(Movie movie);
        void Edit(Movie movie);
        Movie GetMovieById(object id);
        void Delete(object id);
        IEnumerable<Movie> GetAll();
        Movie GetMovieByTitle(string title);
    }
}