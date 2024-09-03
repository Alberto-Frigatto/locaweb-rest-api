using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface IAuthService
    {
        User? Authenticate(string email, string password);
        string GenerateJwtToken(User user);
    }
}
