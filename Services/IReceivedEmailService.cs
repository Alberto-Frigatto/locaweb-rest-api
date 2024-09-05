using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface IReceivedEmailService
    {
        IEnumerable<ReceivedEmail> GetAllReceivedEmails(int page, int idUser);
        IEnumerable<ReceivedEmail> SearchReceivedEmails(string query, int page, int idUser);
        ReceivedEmail? GetReceivedEmailById(int id, int idUser);
    }
}
