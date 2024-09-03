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
            List<ReceivedEmail> allReceivedEmails = _receivedEmailRepository.GetAll(page).ToList();
            allReceivedEmails.ForEach(receivedEmail => {
                receivedEmail.IsDeleted = _deletedReceivedEmailRepository
                    .GetByIdUserAndIdReceivedEmail(idUser, receivedEmail.Id) != null;
                receivedEmail.IsTrash = _trashedEmailRepository
                    .GetByIdUserAndIdReceivedEmail(idUser, receivedEmail.Id) != null;
                receivedEmail.IsFavorite = _favoriteReceivedEmailRepository
                    .GetByIdUserAndIdReceivedEmail(idUser, receivedEmail.Id) != null;
            });

            return allReceivedEmails;
        }
    }
}
