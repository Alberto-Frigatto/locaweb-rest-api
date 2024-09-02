using locaweb_rest_api.Models;
using locaweb_rest_api.Repositories;

namespace locaweb_rest_api.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public void CreateUser(User model, IFormFile image)
        {
            _repository.Add(model);
            SaveUserImage(image);
        }

        async private void SaveUserImage(IFormFile image)
        {
            string imagePath = GetImagePath();

            using (var stream = new FileStream(imagePath, FileMode.Create))
            {
                await image.CopyToAsync(stream);
            }
        }

        private string GetImagePath()
        {
            return Path.Combine(Directory.GetCurrentDirectory(), "uploads", GenerateRandomFileName());
        }

        private static string GenerateRandomFileName()
        {
            return $"{Guid.NewGuid()}.jpg";
        }

        public User? GetUserByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
    }
}
