using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class DeletedReceivedEmailService : IDeletedReceivedEmailService
    {
        private readonly IDeletedReceivedEmailRepository _repository;

        public DeletedReceivedEmailService(IDeletedReceivedEmailRepository repository)
        {
            _repository = repository;
        }

        public void CreateDeletedReceivedEmail(DeletedReceivedEmail model)
        {
            _repository.Add(model);
        }
    }
}
