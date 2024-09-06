using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class TrashedEmailService : ITrashedEmailService
    {
        private readonly ITrashedEmailRepository _repository;

        public TrashedEmailService(ITrashedEmailRepository repository)
        {
            _repository = repository;
        }

        public void CreateTrashedEmail(TrashedEmail model)
        {
            _repository.Add(model);
        }

        public void DeleteTrashedEmailByIdReceivedEmail(int idUser, int idReceivedEmail)
        {
            TrashedEmail? trashedEmail = _repository.GetByIdUserAndIdReceivedEmail(idUser, idReceivedEmail);

            if (trashedEmail != null)
                _repository.Delete(trashedEmail);
        }

        public void DeleteTrashedEmailByIdSentEmail(int idUser, int idSentEmail)
        {
            TrashedEmail? trashedEmail = _repository.GetByIdUserAndIdSentEmail(idUser, idSentEmail);

            if (trashedEmail != null)
                _repository.Delete(trashedEmail);
        }

        public IEnumerable<TrashedEmail> GetAllTrashedEmails(int page, int idUser)
        {
            return _repository.GetAll(page, idUser);
        }

        public TrashedEmail? GetTrashedEmailByIdReceivedEmail(int idUser, int idReceivedEmail)
        {
            return _repository.GetByIdUserAndIdReceivedEmail(idUser, idReceivedEmail);
        }

        public TrashedEmail? GetTrashedEmailByIdSentEmail(int idUser, int idSentEmail)
        {
            return _repository.GetByIdUserAndIdSentEmail(idUser, idSentEmail);
        }
    }
}
