using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Pagination;
using iTechArt.ManagementDemo.Querying.Search;
using iTechArt.ManagementDemo.Querying.Sort;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.Web.Models
{
    public class QueryOptionsModel : IQueryOptions
    {
        public SearchOptions SearchOptions { get; set; }
        public IEnumerable<SortOptions> SortOptions { get; set; }
        public PaginationOptions PaginationOptions { get; set; }

        ISearchOptions IQueryOptions.SearchOptions => SearchOptions;
        IEnumerable<ISortOptions> IQueryOptions.SortOptions => SortOptions;
        IPaginationOptions IQueryOptions.PaginationOptions => PaginationOptions;
    }
}
