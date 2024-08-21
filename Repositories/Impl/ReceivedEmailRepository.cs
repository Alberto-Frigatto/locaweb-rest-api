using locaweb_rest_api.Data.Contexts;
using locaweb_rest_api.Models;

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
            return _context.ReceivedEmails.Skip((page - 1) * page).Take(20).ToList();
        }
    }
}
