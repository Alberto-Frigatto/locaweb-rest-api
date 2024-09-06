using locaweb_rest_api.Models;
using locaweb_rest_api.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace locaweb_rest_api.Repositories.Impl
{
    public class FavoriteReceivedEmailRepository : IFavoriteReceivedEmailRepository
    {
        private readonly DatabaseContext _context;

        public FavoriteReceivedEmailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(FavoriteReceivedEmail model)
        {
            _context.FavoriteReceivedEmails.Add(model);
            _context.SaveChanges();
        }

        public FavoriteReceivedEmail? GetByIdUserAndIdReceivedEmail(int idUser, int idReceivedEmail)
        {
            return _context.FavoriteReceivedEmails.
                FirstOrDefault(e => e.IdUser == idUser && e.IdReceivedEmail == idReceivedEmail);
        }

        public void Delete(FavoriteReceivedEmail model)
        {
            _context.FavoriteReceivedEmails.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<FavoriteReceivedEmail> GetAll(int page, int idUser)
        {
            return _context.FavoriteReceivedEmails
                .Include(e => e.User)
                .Include(e => e.ReceivedEmail)
                .Where(e => e.IdUser == idUser)
                .Skip((page - 1) * 20)
                .Take(20)
                .AsNoTracking()
                .ToList();
        }
    }
}
