using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Contracts
{
    public interface IPeopleRepository : IBaseRepository<People>
    {
        Guid GetDirectorIdForMovie(Movie movie);
    }
}