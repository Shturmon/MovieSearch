using System;
using System.Collections.Generic;
using System.Linq;
using BLL.Contracts;
using DAL.Contracts;
using DAL.Models;

namespace BLL.Services
{
    public class RatingService : IRatingService
    {
        private IRatingRepository _repo;

        public RatingService(IRatingRepository repository)
        {
            _repo = repository;
        }

        public void AddRating(Rating rating)
        {
            _repo.Insert(rating);
            _repo.Save();
        }

        public void Edit(Rating rating)
        {
            _repo.Update(rating);
            _repo.Save();
        }

        public IEnumerable<Rating> GetAll()
        {
            return _repo.Get();
        }

        public double CountRatingByMovieId(Guid movieId)
        {
            return _repo.CountRatingByMovieId(movieId);
        }

        public void DeleteByMovieIdAndUserId(Guid movieId, string userId)
        {
            var oldRating = _repo.Get(m => m.MovieId == movieId && m.UserId == userId).SingleOrDefault();
            _repo.Delete(oldRating);
            _repo.Save();
        }
    }
}