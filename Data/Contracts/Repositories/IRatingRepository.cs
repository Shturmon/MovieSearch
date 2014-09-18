using System;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.Contracts.Repositories
{
    public interface IRatingRepository : IBaseRepository<Rating>
    {
        double CountRatingByMovieId(Guid movieId);
        new void Update(Rating rating);
    }
}