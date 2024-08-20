namespace locaweb_rest_api.Models
{
    public class FavoriteSentEmail
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
        public int? IdReceivedEmail { get; set; }
        public ReceivedEmail? ReceivedEmail { get; set; }
   }
}
