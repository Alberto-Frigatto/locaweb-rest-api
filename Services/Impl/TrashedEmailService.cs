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

        public void DeleteTrashedEmailByIdReceivedEmail(int idReceivedEmail)
        {
            TrashedEmail? trashedEmail = _repository.GetByIdReceivedEmail(idReceivedEmail);

            if (trashedEmail != null)
                _repository.Delete(trashedEmail);
        }

        public void DeleteTrashedEmailByIdSentEmail(int idSentEmail)
        {
            TrashedEmail? trashedEmail = _repository.GetByIdSentEmail(idSentEmail);

            if (trashedEmail != null)
                _repository.Delete(trashedEmail);
        }

        public IEnumerable<TrashedEmail> GetAllTrashedEmails(int page)
        {
            return _repository.GetAll(page);
        }
    }
}
