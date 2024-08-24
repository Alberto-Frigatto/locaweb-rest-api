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

        void ISentEmailRepository.Add(SentEmail model)
        {
            _context.SentEmails.Add(model);
            _context.SaveChanges();
        }

        void ISentEmailRepository.Delete(SentEmail model)
        {
            _context.SentEmails.Remove(model);
            _context.SaveChanges();
        }

        IEnumerable<SentEmail> ISentEmailRepository.GetAll(int page)
        {
            return _context.SentEmails
                .Include(e => e.User)
                .Skip((page - 1) * page)
                .Take(20)
                .AsNoTracking()
                .ToList();
        }

        SentEmail? ISentEmailRepository.GetById(int id)
        {
            return _context.SentEmails
                .Include(e => e.User)
                .FirstOrDefault(e => e.Id == id);
        }

        void ISentEmailRepository.Update(SentEmail model)
        {
            _context.SentEmails.Update(model);
            _context.SaveChanges();
        }
    }
}
