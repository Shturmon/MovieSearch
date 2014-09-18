using MovieSearch.Data.Models;

namespace MovieSearch.Data.Contracts.Repositories
{
    public interface ICareerRepository : IBaseRepository<Career>
    {
        Career GetByTitle(string title);
    }
}