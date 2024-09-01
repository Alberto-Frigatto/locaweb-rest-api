using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface IFavoriteReceivedEmailRepository
    {
        IEnumerable<FavoriteReceivedEmail> GetAll(int page, int idUser);
        void Add(FavoriteReceivedEmail model);
        void Delete(FavoriteReceivedEmail model);
        FavoriteReceivedEmail? GetByIdUserAndIdReceivedEmail(int idUser, int idReceivedEmail);
    }
}
