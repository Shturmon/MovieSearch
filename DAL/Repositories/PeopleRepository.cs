using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories
{
    public class PeopleRepository : BaseRepository<People>, IPeopleRepository
    {
        public PeopleRepository(MoviesContext context)
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