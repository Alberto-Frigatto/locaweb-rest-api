using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface ITrashedEmailRepository
    {
        IEnumerable<TrashedEmail> GetAll(int page);
        void Add(TrashedEmail model);
        void Delete(TrashedEmail model);
    }
}
