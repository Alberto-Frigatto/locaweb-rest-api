using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class FavoriteReceivedEmailService : IFavoriteReceivedEmailService
    {
        private readonly IFavoriteReceivedEmailRepository _repository;

        public FavoriteReceivedEmailService(IFavoriteReceivedEmailRepository repository)
        {
            _repository = repository;
        }

        public void CreateFavoriteReceivedEmail(FavoriteReceivedEmail model)
        {
            _repository.Add(model);
        }

        public void DeleteFavoriteReceivedEmail(int idReceivedEmail)
        {
            FavoriteReceivedEmail? favoriteReceivedEmail = _repository.GetByIdReceivedEmail(idReceivedEmail);

            if (favoriteReceivedEmail != null)
                _repository.Delete(favoriteReceivedEmail);
        }

        public IEnumerable<FavoriteReceivedEmail> GetAllFavoriteReceivedEmails(int page)
        {
            return _repository.GetAll(page);
        }
    }
}
