using System;
using DAL.Models;

namespace DAL.Contracts
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
        double CountRatingByMovieId(Guid movieId);
        new void Update(Rating rating);
    }
}