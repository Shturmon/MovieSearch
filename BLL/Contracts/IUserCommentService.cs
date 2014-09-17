using System.Collections.Generic;
using DAL.Models;

namespace BLL.Contracts
{
    public interface IUserCommentService
    {
        void AddUserComment(UserComment userComment);
        void Edit(UserComment userComment);
        UserComment GetUserCommentById(object id);
        void Delete(object id);
        IEnumerable<UserComment> GetAll();
    }
}