namespace locaweb_rest_api.ViewModels.Out
{
    public class PaginationReceivedEmailViewModel
    {
        public required IEnumerable<OutReceivedEmailViewModel> ReceivedEmails { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => ReceivedEmails.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/api/ReceivedEmail?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/api/ReceivedEmail?page={CurrentPage + 1}" : "";
    }
}
