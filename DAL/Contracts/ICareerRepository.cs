using DAL.Models;

namespace DAL.Contracts
{
    public interface ICareerRepository : IBaseRepository<Career>
    {
        Career GetByTitle(string title);
    }
}