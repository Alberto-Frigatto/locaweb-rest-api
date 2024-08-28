using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface IDeletedReceivedEmailService
    {
        void CreateDeletedReceivedEmail(DeletedReceivedEmail model);
    }
}
