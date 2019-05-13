using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Abstractions;
using System.Linq;

namespace iTechArt.ManagementDemo.DataAccess.Infrastructure.Extensions
{
    public static class QueryOptionsExtensions
    {
        public static IQueryResult<TModel> ApplyOptions<TModel>(
            this IQueryable<TModel> query,
            IQueryOptions options,
            int maxItemsPerPage = 100)
            where TModel : IQueryModel
        {
            query = query.ApplyOptions(
                options.SearchOptions, out var searchOptions);

            var totalCount = query.Count();

            query = query.ApplyOptions(
                options.SortOptions, out var sortOptions);

            query = query.ApplyOptions(
                options.PaginationOptions,
                maxItemsPerPage,
                out var paginationOptions);

            var queryItems = query.ToList();

            var appliedOptions = new QueryOptions(
                searchOptions, sortOptions, paginationOptions);

            return new QueryResult<TModel>(
                queryItems, totalCount, appliedOptions);
        }
    }
}
