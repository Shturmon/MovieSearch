using System;
using System.Data.Entity;
using System.Linq;
using AutoMapper;
using BLL;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories
{
    public class RatingRepository : BaseRepository<Rating>, IRatingRepository
    {
        public RatingRepository(MoviesContext context)
            : base(context)
        {
        }

        public double CountRatingByMovieId(Guid movieId)
        {
            var evaluations = Get(m => m.MovieId == movieId);
            int amount = evaluations.Count();
            double sum = 0.0;
            foreach (var evaluation in evaluations)
            {
                sum += evaluation.ValueOfRating;
            }
            
            return sum/amount;
        }

        public new void Update(Rating rating)
        {
            var dbRating = Get(r => r.MovieId == rating.MovieId && r.UserId == rating.UserId).SingleOrDefault();
            dbRating = Mapper.Map(rating, dbRating);
            dbRating.Movie = rating.Movie;
            dbRating.User = rating.User;

            Context.Entry(dbRating).State = EntityState.Modified;
        }
    }
}