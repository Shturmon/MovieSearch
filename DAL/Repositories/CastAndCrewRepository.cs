using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories
{
    public class CastAndCrewRepository : BaseRepository<CastAndCrew>, ICastAndCrewRepository
    {
        public CastAndCrewRepository(MoviesContext context)
            : base(context)
        {
        }
    }
}