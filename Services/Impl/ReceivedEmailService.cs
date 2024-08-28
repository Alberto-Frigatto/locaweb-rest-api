using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class ReceivedEmailService : IReceivedEmailService
    {
        private readonly IReceivedEmailRepository _repository;

        public ReceivedEmailService(IReceivedEmailRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ReceivedEmail> GetAllReceivedEmails(int page)
        {
            return _repository.GetAll(page);
        }
    }
}
