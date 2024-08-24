using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface IDeletedReceivedEmailRepository
    {
        void Add(DeletedReceivedEmail model);
    }
}
