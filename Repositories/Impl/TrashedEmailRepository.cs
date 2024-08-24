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

        public IEnumerable<TrashedEmail> GetAll(int page)
        {
            return _context.TrashedEmails
                .Include(e => e.User)
                .Include(e => e.ReceivedEmail)
                .Include(e => e.SentEmail)
                .Skip((page - 1) * page)
                .Take(20)
                .AsNoTracking()
                .ToList();
        }
    }
}
