using DAL.Models;

namespace DAL.Contracts
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Country GetByTitle(string title);
    }
}