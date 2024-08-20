namespace locaweb_rest_api.Models
{
    public class TrashedEmail
    {
        public int Id { get; set; }
        public int? IdReceivedEmail { get; set; }
        public ReceivedEmail? ReceivedEmail { get; set; }
        public int? IdSentEmail { get; set; }
        public SentEmail? SentEmail { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
