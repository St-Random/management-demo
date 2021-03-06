﻿using iTechArt.ManagementDemo.DataAccess.Infrastructure.Helpers;
using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Search;
using System;
using System.Linq;

namespace iTechArt.ManagementDemo.DataAccess.Infrastructure.Extensions
{
    public static class SearchOptionsExtensions
    {
        public static IQueryable<TModel> ApplyOptions<TModel>(
            this IQueryable<TModel> query,
            ISearchOptions options,
            out ISearchOptions appliedOptions)
            where TModel : IQueryModel
        {
            if (options == null)
            {
                appliedOptions = null;

                return query;
            }

            var propertiesToSearch = ReflectionHelper
                .GetPropertyNamesThatAllowSearch<TModel>();

            appliedOptions =
                new SearchOptions
                {
                    PropertyNames = 
                        (options.PropertyNames ?? Enumerable.Empty<string>())
                            .Where(
                                name => propertiesToSearch.Contains(name))
                            .ToList(),
                    Term = options.Term
                };

            if (!appliedOptions.PropertyNames.Any()
                || string.IsNullOrEmpty(appliedOptions.Term))
            {
                return query;
            }

            var searchExpression = ReflectionHelper
                .CreateSearchExpressionFor<TModel>(
                    appliedOptions.PropertyNames, appliedOptions.Term);

            return query.Where(searchExpression);
        }
    }
}
