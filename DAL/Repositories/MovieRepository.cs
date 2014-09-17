using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DAL.Contracts;
using DAL.Models;
using System.Data.Entity;

namespace DAL.Repositories
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MoviesContext context)
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