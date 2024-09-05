using locaweb_rest_api.Models;

namespace locaweb_rest_api.Repositories
{
    public interface IReceivedEmailRepository
    {
        IEnumerable<ReceivedEmail> GetAll(int page, int idUser);
        IEnumerable<ReceivedEmail> Search(string query, int page, int idUser);
        ReceivedEmail? GetById(int id, int idUser);
    }
}
