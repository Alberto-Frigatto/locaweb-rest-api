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

        public IEnumerable<ReceivedEmail> GetAll(int page)
        {
            return _context.ReceivedEmails
                .Where(e => !_context.TrashedEmails.Any(te => te.IdReceivedEmail == e.Id) &&
                            !_context.DeletedReceivedEmails.Any(de => de.IdReceivedEmail == e.Id))
                .OrderBy(e => e.Id)
                .Skip((page - 1) * 20)
                .Take(20)
                .AsNoTracking()
                .ToList();
        }
    }
}
