using System.Linq;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.DAL.Context;
using MovieSearch.Data.Models;

namespace MovieSearch.Data.DAL.Repositories
{
    public class GenreRepository : BaseRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MoviesDbContext context)
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