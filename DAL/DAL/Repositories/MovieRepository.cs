using System.Data.Entity;
using AutoMapper;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesDbContext context)
            : base(context)
        {
        }

        public new void Update(Movie movie)
        {
            var dbMovie = GetById(movie.Id);
            dbMovie = Mapper.Map(movie, dbMovie);
            dbMovie.Genres.Clear();
            dbMovie.CastAndCrews.Clear();
            
            foreach (var genre in movie.Genres)
            {
                dbMovie.Genres.Add(genre);
            }
            foreach (var cast in movie.CastAndCrews)
            {
                dbMovie.CastAndCrews.Add(cast);
            }

            Context.Entry(dbMovie).State = EntityState.Modified;
        }
    }
}