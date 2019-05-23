using iTechArt.ManagementDemo.DataAccess.Infrastructure.Extensions;
using iTechArt.ManagementDemo.Querying;
using iTechArt.ManagementDemo.Querying.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArt.ManagementDemo.DataAccess.EF.Infrastructure.Extensions
{
    public static class AsyncQueryExtensions
    {
        public static async Task<IQueryResult<TModel>>
            ApplyOptionsAsync<TModel>(
                this IQueryable<TModel> query,
                IQueryOptions options,
                int maxItemsPerPage = 100)
                where TModel : IQueryModel
        {
            options = options ?? new QueryOptions();

            query = query.ApplyOptions(
                options.SearchOptions, out var searchOptions);

            var totalCount = query.Count();

            query = query.ApplyOptions(
                options.SortOptions, out var sortOptions);

            query = query.ApplyOptions(
                options.PaginationOptions,
                maxItemsPerPage,
                out var paginationOptions);

            var queryItems = await query.ToListAsync();

            var appliedOptions = new QueryOptions(
                searchOptions, sortOptions, paginationOptions);

            return new QueryResult<TModel>(
                queryItems, totalCount, appliedOptions);
        }
    }
}
