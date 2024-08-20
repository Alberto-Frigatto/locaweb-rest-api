namespace locaweb_rest_api.Models
{
    public class SentEmail
    {
        public int Id { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime TimeStamp { get; set; }
        public DateTime SendDate { get; set; }
        public bool Viewed { get; set; }
        public bool Scheduled { get; set; }
        public int IdUser { get; set; }
        public User User { get; set; }
    }
}
