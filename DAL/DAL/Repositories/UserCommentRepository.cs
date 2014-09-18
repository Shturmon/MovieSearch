using System;
using System.Collections.Generic;
using System.Linq;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Repositories
{
    public class UserCommentRepository : BaseRepository<UserComment>, IUserCommentRepository
    {
        public UserCommentRepository(MoviesDbContext context)
            : base(context)
        {
        }

        public IEnumerable<UserComment> GetCommentsByMovieId(Guid movieId)
        {
            return Context.UserComments.Where(x => x.MovieId == movieId);
        }
    }
}