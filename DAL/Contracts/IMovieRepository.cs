using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Contracts
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        new void Update(Movie movie);
    }
}
