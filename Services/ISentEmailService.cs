using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface ISentEmailService
    {
        IEnumerable<SentEmail> GetAllSentEmails(int page);
        SentEmail? GetSentEmailById(int id);
        void CreateSentEmail(SentEmail model);
        void UpdateSentEmail(SentEmail model);
        void DeleteSentEmail(int id);
    }
}
