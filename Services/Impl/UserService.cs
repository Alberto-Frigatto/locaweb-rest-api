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

        async public void CreateUser(User model, IFormFile image)
        {
            string newImagePath = GetImagePath();
            model.Image = newImagePath.Split("/").Last();

            _repository.Add(model);
             await SaveUserImage(image, newImagePath);
        }

        async private Task SaveUserImage(IFormFile image, string imagePath)
        {
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
            return $"{Guid.NewGuid()}.jpg".Replace("-", "");
        }

        public User? GetUserByEmail(string email)
        {
            return _repository.GetByEmail(email);
        }
    }
}
