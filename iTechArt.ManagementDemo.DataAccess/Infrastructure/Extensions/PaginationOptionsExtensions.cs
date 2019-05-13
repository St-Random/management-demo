using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Pagination;
using System;
using System.Linq;

namespace iTechArt.ManagementDemo.DataAccess.Infrastructure.Extensions
{
    public static class PaginationOptionsExtensions
    {
        public static IQueryable<TModel> ApplyOptions<TModel>(
            this IQueryable<TModel> query,
            IPaginationOptions options,
            int maxItemsPerPage,
            out IPaginationOptions appliedOptions)
            where TModel : IQueryModel
        {
            if (options == null)
            {
                appliedOptions = null;

                return query.Take(maxItemsPerPage);
            }

            appliedOptions =
                new PaginationOptions
                {
                    ItemsPerPage = Math.Max(
                        Math.Min(options.ItemsPerPage, maxItemsPerPage), 1),
                    Page = Math.Max(options.Page, 1)
                };

            return query.ApplyOptions(appliedOptions);
        }


        private static IQueryable<TModel> ApplyOptions<TModel>(
            this IQueryable<TModel> query, IPaginationOptions options)
            where TModel : IQueryModel =>
            query
                .Skip((options.Page - 1) * options.ItemsPerPage)
                .Take(options.ItemsPerPage);
    }
}
