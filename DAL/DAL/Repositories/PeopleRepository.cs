using System;
using System.Linq;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Repositories
{
    public class PeopleRepository : BaseRepository<People>, IPeopleRepository
    {
        public PeopleRepository(MoviesDbContext context)
            : base(context)
        {
            
        }

        public Guid GetDirectorIdForMovie(Movie movie)
        {
            var director = Context.CastAndCrews.SingleOrDefault(y => y.MovieId == movie.Id && 
                                                                y.Career.Title == "Director");
            return director != null ? director.PeopleId : new Guid();
        }
    }
}