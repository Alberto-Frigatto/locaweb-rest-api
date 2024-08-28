using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface IFavoriteReceivedEmailService
    {
        IEnumerable<FavoriteReceivedEmail> GetAllFavoriteReceivedEmails(int page);
        void CreateFavoriteReceivedEmail(FavoriteReceivedEmail model);
        void DeleteFavoriteReceivedEmail(int idReceivedEmail);
    }
}
