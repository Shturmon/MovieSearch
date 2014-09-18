using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Repositories
{
    public class CastAndCrewRepository : BaseRepository<CastAndCrew>, ICastAndCrewRepository
    {
        public CastAndCrewRepository(MoviesDbContext context)
            : base(context)
        {
        }
    }
}