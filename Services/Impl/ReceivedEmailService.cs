using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class ReceivedEmailService : IReceivedEmailService
    {
        private readonly IReceivedEmailRepository _receivedEmailRepository;
        private readonly ITrashedEmailRepository _trashedEmailRepository;
        private readonly IFavoriteReceivedEmailRepository _favoriteReceivedEmailRepository;
        private readonly IDeletedReceivedEmailRepository _deletedReceivedEmailRepository;

        public ReceivedEmailService(
            IReceivedEmailRepository receivedEmailRepository,
            ITrashedEmailRepository trashedEmailRepository,
            IFavoriteReceivedEmailRepository favoriteReceivedEmailRepository,
            IDeletedReceivedEmailRepository deletedReceivedEmailRepository
        ) {
            _receivedEmailRepository = receivedEmailRepository;
            _trashedEmailRepository = trashedEmailRepository;
            _favoriteReceivedEmailRepository = favoriteReceivedEmailRepository;
            _deletedReceivedEmailRepository = deletedReceivedEmailRepository;
        }

        public IEnumerable<ReceivedEmail> GetAllReceivedEmails(int page, int idUser)
        {
            List<ReceivedEmail> receivedEmails = _receivedEmailRepository.GetAll(page, idUser).ToList();
            receivedEmails.ForEach(receivedEmail => {
                receivedEmail.IsFavorite = _favoriteReceivedEmailRepository
                    .GetByIdUserAndIdReceivedEmail(idUser, receivedEmail.Id) != null;
            });

            return receivedEmails;
        }

        public ReceivedEmail? GetReceivedEmailById(int id, int idUser)
        {
            ReceivedEmail? receivedEmail = _receivedEmailRepository.GetById(id, idUser);

            if (receivedEmail != null)
            {
                receivedEmail.IsFavorite = _favoriteReceivedEmailRepository
                    .GetByIdUserAndIdReceivedEmail(idUser, receivedEmail.Id) != null;
            }

            return receivedEmail;
        }

        public IEnumerable<ReceivedEmail> SearchReceivedEmails(string query, int page, int idUser)
        {
            List<ReceivedEmail> receivedEmails = _receivedEmailRepository.Search(query, page, idUser).ToList();
            receivedEmails.ForEach(receivedEmail => {
                receivedEmail.IsFavorite = _favoriteReceivedEmailRepository
                    .GetByIdUserAndIdReceivedEmail(idUser, receivedEmail.Id) != null;
            });

            return receivedEmails;
        }
    }
}
