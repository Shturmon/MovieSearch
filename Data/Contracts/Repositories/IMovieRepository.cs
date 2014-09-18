using MovieSearch.Data.Models;

namespace MovieSearch.Data.Contracts.Repositories
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        new void Update(Movie movie);
    }
}
