using iTechArt.ManagementDemo.Querying.Abstractions;
using System.Collections.Generic;

namespace iTechArt.ManagementDemo.Querying
{
    public interface IQueryResult<TModel> where TModel : IQueryModel
    {
        IEnumerable<TModel> Items { get; }
        int TotalCount { get; }
        IQueryOptions Options { get; }
    }
}
