using System;
using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.Contracts.Repositories
{
    public interface IUserCommentRepository : IBaseRepository<UserComment>
    {
        IEnumerable<UserComment> GetCommentsByMovieId(Guid movieId);
    }
}