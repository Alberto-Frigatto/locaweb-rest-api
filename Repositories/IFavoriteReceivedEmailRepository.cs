using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface IFavoriteReceivedEmailRepository
    {
        IEnumerable<FavoriteReceivedEmail> GetAll(int page);
        void Add(FavoriteReceivedEmail model);
        void Delete(FavoriteReceivedEmail model);
        FavoriteReceivedEmail? GetByIdReceivedEmail(int idReceivedEmail);
    }
}
