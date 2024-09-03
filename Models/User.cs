namespace locaweb_rest_api.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Image {  get; set; }
        public string Language { get; set; }
        public bool Theme { get; set; }
    }
}
