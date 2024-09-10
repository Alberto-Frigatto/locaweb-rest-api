using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface IUserService
    {
        User? GetUserByEmail(string email);
        User? GetUserById(int id);
        void CreateUser(User model);
        void UpdateUserPreferences(User model);
    }
}
