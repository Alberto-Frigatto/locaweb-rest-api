namespace locaweb_rest_api.ViewModels.Out
{
    public class PaginationTrashedEmailViewModel
    {
        public required IEnumerable<object> TrashedEmails { get; set; }
        public int CurrentPage { get; set; }
        public readonly int PageSize = 20;
        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => TrashedEmails.Count() == PageSize;
        public string PreviousPageUrl => HasPreviousPage ? $"/api/TrashedEmail?page={CurrentPage - 1}" : "";
        public string NextPageUrl => HasNextPage ? $"/api/TrashedEmail?page={CurrentPage + 1}" : "";
    }
}
