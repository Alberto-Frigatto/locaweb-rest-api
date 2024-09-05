using locaweb_rest_api.Data.Contexts;
using locaweb_rest_api.Models;
using Microsoft.EntityFrameworkCore;

namespace locaweb_rest_api.Repositories.Impl
{
    public class ReceivedEmailRepository : IReceivedEmailRepository
    {
        private readonly DatabaseContext _context;

        public ReceivedEmailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public IEnumerable<ReceivedEmail> GetAll(int page, int idUser)
        {
            return _context.ReceivedEmails
                .Where(e => !_context.TrashedEmails.Any(te => te.IdReceivedEmail == e.Id && te.IdUser == idUser) &&
                            !_context.DeletedReceivedEmails.Any(de => de.IdReceivedEmail == e.Id && de.IdUser == idUser))
                .OrderBy(e => e.Id)
                .Skip((page - 1) * 20)
                .Take(20)
                .AsNoTracking()
                .ToList();
        }

        public ReceivedEmail? GetById(int id, int idUser)
        {
            return _context.ReceivedEmails
                .Where(e => e.Id == id &&
                            !_context.TrashedEmails.Any(te => te.IdReceivedEmail == e.Id && te.IdUser == idUser) &&
                            !_context.DeletedReceivedEmails.Any(de => de.IdReceivedEmail == e.Id && de.IdUser == idUser))
                .FirstOrDefault();
        }
    }
}
