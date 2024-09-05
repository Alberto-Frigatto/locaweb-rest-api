using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface ISentEmailRepository
    {
        IEnumerable<SentEmail> GetAll(int page, int idUser);
        SentEmail? GetById(int id);
        SentEmail? GetLast(int idUser);
        void Add(SentEmail model);
        void Update(SentEmail model);
        void Delete(SentEmail model);
    }
}
