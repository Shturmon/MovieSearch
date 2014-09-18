using System.Collections.Generic;
using MovieSearch.Data.Contracts.Repositories;
using MovieSearch.Data.Models;
using MovieSearch.Logic.Contracts.Services;

namespace MovieSearch.Logic.BLL.Services
{
    public class UserCommentService : IUserCommentService
    {
        private IUserCommentRepository _repo;

        public UserCommentService(IUserCommentRepository repository)
        {
            _repo = repository;
        }

        public void AddUserComment(UserComment userComment)
        {
            _repo.Insert(userComment);
            _repo.Save();
        }

        public void Edit(UserComment userComment)
        {
            _repo.Update(userComment);
            _repo.Save();
        }

        public UserComment GetUserCommentById(object id)
        {
            return _repo.GetById(id);
        }

        public void Delete(object id)
        {
            _repo.Delete(id);
            _repo.Save();
        }

        public IEnumerable<UserComment> GetAll()
        {
            return _repo.Get();
        }
    }
}