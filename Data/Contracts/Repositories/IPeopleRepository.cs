using System;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.Contracts.Repositories
{
    public interface IPeopleRepository : IBaseRepository<People>
    {
        Guid GetDirectorIdForMovie(Movie movie);
    }
}