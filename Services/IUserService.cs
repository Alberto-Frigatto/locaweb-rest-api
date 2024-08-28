using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface IUserService
    {
        User? GetUserByEmail(string email);
        void CreateUser(User model, IFormFile image);
    }
}
