using iTechArt.ManagementDemo.Querying.Search;
using iTechArt.ManagementDemo.Querying.Sort;
using iTechArt.ManagementDemo.Querying.Pagination;
using System.Collections.Generic;

namespace iTechArt.ManagementDemo.Querying
{
    public interface IQueryOptions
    {
        ISearchOptions SearchOptions { get; }
        IEnumerable<ISortOptions> SortOptions { get; }
        IPaginationOptions PaginationOptions { get; }
    }
}
