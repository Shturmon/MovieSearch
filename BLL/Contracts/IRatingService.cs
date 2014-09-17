using System;
using System.Collections.Generic;
using DAL.Models;

namespace BLL.Contracts
{
    public interface IRatingService
    {
        void AddRating(Rating rating);
        void Edit(Rating rating);
        IEnumerable<Rating> GetAll();
        double CountRatingByMovieId(Guid movieId);
        void DeleteByMovieIdAndUserId(Guid movieId, string userId);
    }
}