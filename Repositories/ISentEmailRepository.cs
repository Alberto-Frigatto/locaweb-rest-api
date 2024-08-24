using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface ISentEmailRepository
    {
        IEnumerable<SentEmail> GetAll(int page);
        SentEmail? GetById(int id);
        void Add(SentEmail model);
        void Update(SentEmail model);
        void Delete(SentEmail model);
    }
}
