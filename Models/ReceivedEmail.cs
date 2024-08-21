namespace locaweb_rest_api.Models
{
    public class ReceivedEmail
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
        public string Image { get; set; }
    }
}
