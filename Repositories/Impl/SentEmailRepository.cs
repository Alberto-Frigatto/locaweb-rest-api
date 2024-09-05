using locaweb_rest_api.Models;
using locaweb_rest_api.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace locaweb_rest_api.Repositories.Impl
{
    public class SentEmailRepository : ISentEmailRepository
    {
        private readonly DatabaseContext _context;

        public SentEmailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(SentEmail model)
        {
            _context.SentEmails.Add(model);
            _context.SaveChanges();
        }

        public void Delete(SentEmail model)
        {
            _context.SentEmails.Remove(model);
            _context.SaveChanges();
        }

        public IEnumerable<SentEmail> GetAll(int page, int idUser)
        {
            return _context.SentEmails
                .Where(e => e.IdUser == idUser &&
                        !_context.TrashedEmails.Any(te => te.IdSentEmail == e.Id && te.IdUser == idUser))
                .OrderByDescending(e => e.Id)
                .Skip((page - 1) * 20)
                .Take(20)
                .AsNoTracking()
                .ToList();
        }

        public SentEmail? GetById(int id)
        {
            return _context.SentEmails
                .FirstOrDefault(e => e.Id == id);
        }
        
        public SentEmail? GetLast(int idUser)
        {
            return _context.SentEmails
                .Where(e => e.IdUser == idUser)
                .OrderByDescending(e => e.Id)
                .FirstOrDefault();
        }

        public void Update(SentEmail model)
        {
            _context.SentEmails.Update(model);
            _context.SaveChanges();
        }
    }
}
