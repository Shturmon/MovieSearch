using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Logic.Contracts.Services
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