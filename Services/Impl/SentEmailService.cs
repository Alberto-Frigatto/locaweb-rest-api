using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class SentEmailService : ISentEmailService
    {
        private readonly ISentEmailRepository _repository;

        public SentEmailService(ISentEmailRepository repository)
        {
            _repository = repository;
        }

        public void CreateSentEmail(SentEmail model)
        {
            _repository.Add(model);
        }

        public void DeleteSentEmail(int id)
        {
            SentEmail? sentEmail = _repository.GetById(id);

            if (sentEmail != null)
                _repository.Delete(sentEmail);
        }

        public IEnumerable<SentEmail> GetAllSentEmails(int page, int idUser)
        {
            return _repository.GetAll(page, idUser);
        }

        public SentEmail? GetSentEmailById(int id)
        {
            return _repository.GetById(id);
        }

        public void UpdateSentEmail(SentEmail model)
        {
            _repository.Update(model);
        }
    }
}
