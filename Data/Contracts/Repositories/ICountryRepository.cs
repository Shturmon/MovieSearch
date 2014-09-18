using MovieSearch.Data.Models;

namespace MovieSearch.Data.Contracts.Repositories
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Country GetByTitle(string title);
    }
}