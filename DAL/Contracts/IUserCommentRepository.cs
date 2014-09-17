using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Contracts
{
    public interface IUserCommentRepository : IBaseRepository<UserComment>
    {
        IEnumerable<UserComment> GetCommentsByMovieId(Guid movieId);
    }
}