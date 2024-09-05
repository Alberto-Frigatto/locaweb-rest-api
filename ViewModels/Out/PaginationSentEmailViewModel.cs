namespace locaweb_rest_api.ViewModels.Out
{
    public class PaginationSentEmailViewModel
    {
        public required IEnumerable<OutSentEmailViewModel> SentEmails { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => SentEmails.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/api/SentEmail?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/api/SentEmail?page={CurrentPage + 1}" : "";
    }
}
