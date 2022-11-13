namespace Review.Contracts.Pagination
{
    /// <summary>
    /// Pagination context.
    /// </summary>
    public class PaginationContext
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public int Pages { get; set; }

        public int TotalRows { get; set; }
    }
}