using System.ComponentModel.DataAnnotations.Schema;

namespace locaweb_rest_api.ViewModels.Out
{
    public class OutReceivedEmailViewModel
    {
        public int Id { get; set; }
        public string Sender { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
