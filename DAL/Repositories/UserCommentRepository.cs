using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories
{
    public class UserCommentRepository : BaseRepository<UserComment>, IUserCommentRepository
    {
        public UserCommentRepository(MoviesContext context)
            : base(context)
        {
        }

        public IEnumerable<UserComment> GetCommentsByMovieId(Guid movieId)
        {
            return Context.UserComments.Where(x => x.MovieId == movieId);
        }
    }
}