using iTechArt.ManagementDemo.DataAccess.Infrastructure.Helpers;
using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Sort;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iTechArt.ManagementDemo.DataAccess.Infrastructure.Extensions
{
    public static class SortOptionsExtensions
    {
        public static IQueryable<TModel> ApplyOptions<TModel>(
            this IQueryable<TModel> query,
            IEnumerable<ISortOptions> options,
            out IEnumerable<ISortOptions> appliedOptions)
            where TModel : IQueryModel
        {
            if (options == null)
            {
                appliedOptions = null;

                return query.ApplyDefaultOptions();
            }

            var propertiesToSort = ReflectionHelper
                .GetPropertyNamesThatAllowSort<TModel>();

            appliedOptions = options
                .Where(opt => propertiesToSort.Contains(opt.PropertyName))
                .ToList();

            if (!appliedOptions.Any())
            {
                return query.ApplyDefaultOptions();
            }

            var orderedQuery = query.ApplyOptions(appliedOptions.First());

            foreach (var option in appliedOptions.Skip(1))
            {
                orderedQuery = orderedQuery.ApplyOptions(option);
            }

            return orderedQuery.ApplyDefaultOptions();
        }

        private static IOrderedQueryable<TModel> ApplyDefaultOptions<TModel>(
            this IOrderedQueryable<TModel> query)
            where TModel : IQueryModel =>
            query.ApplyOptions(
                new SortOptions {
                    PropertyName = nameof(IQueryModel.Id),
                    SortDirection = SortDirection.Ascending
                });

        private static IOrderedQueryable<TModel> ApplyDefaultOptions<TModel>(
            this IQueryable<TModel> query)
            where TModel : IQueryModel =>
            query.ApplyOptions(
                new SortOptions
                {
                    PropertyName = nameof(IQueryModel.Id),
                    SortDirection = SortDirection.Ascending
                });

        private static IOrderedQueryable<TModel> ApplyOptions<TModel>(
            this IOrderedQueryable<TModel> query, ISortOptions options)
            where TModel : IQueryModel
        {
            var propertySelectorExpression = ReflectionHelper
                .GetPropertySelectorExpressionFor<TModel, IComparable>(
                    options.PropertyName);

            return options.SortDirection == SortDirection.Ascending
                ? query.ThenBy(propertySelectorExpression)
                : query.ThenByDescending(propertySelectorExpression);
        }

        private static IOrderedQueryable<TModel> ApplyOptions<TModel>(
            this IQueryable<TModel> query, ISortOptions options)
            where TModel : IQueryModel
        {
            var propertySelectorExpression = ReflectionHelper
                .GetPropertySelectorExpressionFor<TModel, IComparable>(
                    options.PropertyName);

            return options.SortDirection == SortDirection.Ascending
                ? query.OrderBy(propertySelectorExpression)
                : query.OrderByDescending(propertySelectorExpression);
        }
    }
}
