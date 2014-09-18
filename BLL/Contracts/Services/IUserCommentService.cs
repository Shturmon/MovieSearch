using System.Collections.Generic;
using MovieSearch.Data.Models;

namespace MovieSearch.Logic.Contracts.Services
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