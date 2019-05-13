using System.Collections.Generic;
using iTechArt.ManagementDemo.Querying.Pagination;
using iTechArt.ManagementDemo.Querying.Search;
using iTechArt.ManagementDemo.Querying.Sort;

namespace iTechArt.ManagementDemo.Querying
{
    public class QueryOptions : IQueryOptions
    {
        public ISearchOptions SearchOptions { get; set; }
        public IEnumerable<ISortOptions> SortOptions { get; set; }
        public IPaginationOptions PaginationOptions { get; set; }

        public QueryOptions()
        { }

        public QueryOptions(
            ISearchOptions searchOptions,
            IEnumerable<ISortOptions> sortOptions,
            IPaginationOptions paginationOptions)
        {
            SearchOptions = searchOptions;
            SortOptions = sortOptions;
            PaginationOptions = paginationOptions;
        }
    }
}
