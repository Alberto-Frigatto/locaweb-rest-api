using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface ITrashedEmailRepository
    {
        IEnumerable<TrashedEmail> GetAll(int page, int idUser);
        void Add(TrashedEmail model);
        void Delete(TrashedEmail model);
        TrashedEmail? GetByIdUserAndIdReceivedEmail(int idUser, int idReceivedEmail);
        TrashedEmail? GetByIdUserAndIdSentEmail(int idUser, int idSentEmail);
    }
}
