using System;
using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Logic.Contracts.Services
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