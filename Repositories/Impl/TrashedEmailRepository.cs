using locaweb_rest_api.Models;
using locaweb_rest_api.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace locaweb_rest_api.Repositories.Impl
{
    public class TrashedEmailRepository : ITrashedEmailRepository
    {
        private readonly DatabaseContext _context;

        public TrashedEmailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(TrashedEmail model)
        {
            _context.TrashedEmails.Add(model);
            _context.SaveChanges();
        }

        public void Delete(TrashedEmail model)
        {
            _context.TrashedEmails.Remove(model);
            _context.SaveChanges();
        }

        public TrashedEmail? GetByIdUserAndIdReceivedEmail(int idUser, int idReceivedEmail)
        {
            return _context.TrashedEmails.
                FirstOrDefault(e => e.IdUser == idUser && e.IdReceivedEmail == idReceivedEmail);
        }

        public TrashedEmail? GetByIdUserAndIdSentEmail(int idUser, int idSentEmail)
        {
            return _context.TrashedEmails.
                FirstOrDefault(e => e.IdUser == idUser && e.IdSentEmail == idSentEmail);
        }

        public IEnumerable<TrashedEmail> GetAll(int page, int idUser)
        {
            return _context.TrashedEmails
                .Include(e => e.ReceivedEmail)
                .Include(e => e.SentEmail)
                .OrderByDescending(e => e.Id)
                .Where(e => e.IdUser == idUser)
                .Skip((page - 1) * page)
                .Take(20)
                .AsNoTracking()
                .ToList();
        }
    }
}
