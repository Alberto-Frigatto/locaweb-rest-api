using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface ISentEmailService
    {
        IEnumerable<SentEmail> GetAllSentEmails(int page, int idUser);
        IEnumerable<SentEmail> GetAllScheduledSentEmails(int page, int idUser);
        IEnumerable<SentEmail> SearchSentEmails(string query, int page, int idUser);
        SentEmail? GetSentEmailById(int id);
        SentEmail? GetLastSentEmail(int idUser);
        void CreateSentEmail(SentEmail model);
        void UpdateSentEmail(SentEmail model);
        void DeleteSentEmail(int id);
    }
}
