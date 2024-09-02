using locaweb_rest_api.Models;

namespace locaweb_rest_api.Services
{
    public interface ITrashedEmailService
    {
        IEnumerable<TrashedEmail> GetAllTrashedEmails(int page, int idUser);
        void CreateTrashedEmail(TrashedEmail model);
        void DeleteTrashedEmailByIdReceivedEmail(int idUser, int idReceivedEmail);
        void DeleteTrashedEmailByIdSentEmail(int idUser, int idSentEmail);
    }
}
