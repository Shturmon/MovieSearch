using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Contracts;
using DAL.Models;

namespace DAL.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MoviesContext context)
            : base(context)
        {
        }

        public Genre GetByTitle(string title)
        {
            return Context.Genres.FirstOrDefault((c => c.Title == title));
        }

        public override void Insert(Genre genre)
        {
            if (genre == null)
                return;

            var dbGenre = GetByTitle(genre.Title);
            if (dbGenre == null)
                DbSet.Add(genre);
        }
    }
}