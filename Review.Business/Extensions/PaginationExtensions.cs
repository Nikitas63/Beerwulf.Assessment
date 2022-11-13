using System.Linq;
using System.Threading.Tasks;
using Review.Contracts.Pagination;
using X.PagedList;

namespace Review.Business.Extensions
{
    /// <summary>
    /// Helper methods for pagination using.
    /// </summary>
    public static class PaginationExtensions
    {
        public static async Task<Page<TData>> ToPageAsync<TData>(this IQueryable<TData> queryable, int pageNumber, int pageSize)
        {
            var pagedList = await queryable.ToPagedListAsync(pageNumber, pageSize);
            var paginationContext = new PaginationContext
            {
                Page = pagedList.PageNumber,
                Size = pagedList.PageSize,
                Pages = pagedList.PageCount,
                TotalRows = pagedList.TotalItemCount
            };
            return new Page<TData>
            {
                Data = pagedList,
                PaginationContext = paginationContext
            };
        }
    }
}