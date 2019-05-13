using iTechArt.ManagementDemo.Querying.Abstractions;
using System.Collections.Generic;

namespace iTechArt.ManagementDemo.Querying
{
    public class QueryResult<TModel> : IQueryResult<TModel>
        where TModel : IQueryModel
    {
        public IEnumerable<TModel> Items { get; }
        public int TotalCount { get; }
        public IQueryOptions Options { get; }

        public QueryResult(
            IEnumerable<TModel> items,
            int totalCount,
            IQueryOptions options)
        {
            Items = items;
            TotalCount = totalCount;
            Options = options;
        }
    }
}
