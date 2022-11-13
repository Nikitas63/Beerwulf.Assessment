using System.Collections.Generic;

namespace Review.Resources.Pagination
{
    public class PageResource<TData>
    {
        public IEnumerable<TData> Data { get; set; }
        
        public PaginationContextResource PaginationContext { get; set; }
    }
}