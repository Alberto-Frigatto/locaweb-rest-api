using locaweb_rest_api.Models;
using locaweb_rest_api.Data.Contexts;

namespace locaweb_rest_api.Repositories.Impl
{
    public class DeletedReceivedEmailRepository : IDeletedReceivedEmailRepository
    {
        private readonly DatabaseContext _context;

        public DeletedReceivedEmailRepository(DatabaseContext context)
        {
            _context = context;
        }

        public void Add(DeletedReceivedEmail model)
        {
            _context.DeletedEmails.Add(model);
            _context.SaveChanges();
        }
    }
}
