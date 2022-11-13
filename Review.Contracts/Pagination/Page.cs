using System.Collections.Generic;

namespace Review.Contracts.Pagination
{
    /// <summary>
    /// Page of paginated result.
    /// </summary>
    public class Page<TData>
    {
        public IEnumerable<TData> Data { get; set; }
        
        public PaginationContext PaginationContext { get; set; }
    }
}