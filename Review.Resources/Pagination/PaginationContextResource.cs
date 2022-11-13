namespace Review.Resources.Pagination
{
    public class PaginationContextResource
    {
        public int Page { get; set; }

        public int Size { get; set; }

        public int Pages { get; set; }

        public int TotalRows { get; set; }
    }
}