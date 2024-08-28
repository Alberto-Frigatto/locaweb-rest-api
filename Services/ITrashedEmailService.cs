using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface ITrashedEmailService
    {
        IEnumerable<TrashedEmail> GetAllTrashedEmails(int page);
        void CreateTrashedEmail(TrashedEmail model);
        void DeleteTrashedEmailByIdReceivedEmail(int idReceivedEmail);
        void DeleteTrashedEmailByIdSentEmail(int idSentEmail);
    }
}
