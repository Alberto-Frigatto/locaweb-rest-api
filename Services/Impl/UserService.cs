using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void CreateUser(User model)
        {
            _repository.Add(model);
        }

        public User? GetUserByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
        
        public User? GetUserById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateUserPreferences(User model)
        {
            _repository.Update(model);
        }
    }
}
