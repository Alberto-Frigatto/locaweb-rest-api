using System.ComponentModel.DataAnnotations.Schema;


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
        [NotMapped]
        public bool isFavorite { get; set; }
        [NotMapped]
        public bool isTrash { get; set; }
        [NotMapped]
        public bool isDeleted { get; set; }
    }
}
