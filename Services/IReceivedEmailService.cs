using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface IReceivedEmailService
    {
        IEnumerable<ReceivedEmail> GetAllReceivedEmails(int page);
    }
}
