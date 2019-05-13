using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace iTechArt.ManagementDemo.DataAccess.Infrastructure.Helpers
{
    internal static class ReflectionHelper
    {
        internal static Expression<Func<TModel, TProperty>>
            GetPropertySelectorExpressionFor<TModel, TProperty>(
                string propertyName)
            where TModel : IQueryModel
        {
            var paramExpression = Expression.Parameter(typeof(TModel));
            var propertyExpression = Expression.Property(
                paramExpression, propertyName);

            var propertyInfo = (PropertyInfo)propertyExpression.Member;

            if (propertyInfo.PropertyType.Equals(typeof(TProperty)))
            {
                return Expression
                    .Lambda<Func<TModel, TProperty>>(
                        propertyExpression, paramExpression);
            }

            var conversion = Expression.Convert(
                propertyExpression, typeof(TProperty));

            return Expression
                .Lambda<Func<TModel, TProperty>>(
                    conversion, paramExpression);
        }

        internal static Expression<Func<TModel, bool>>
            CreateSearchExpressionFor<TModel>(
                IEnumerable<string> propertyNamesToSearch,
                string searchTerm)
            where TModel : IQueryModel
        {
            var propertiesToSearch = propertyNamesToSearch
                .Select(n => typeof(TModel).GetProperty(n));
            var paramExpression = Expression.Parameter(typeof(TModel));
            var bodyExpression = CreateSearchExpressionFor<TModel>(
                paramExpression, propertiesToSearch.First(), searchTerm);

            foreach (var prop in propertiesToSearch.Skip(1))
            {
                bodyExpression = CreateOrElseExpression(
                    bodyExpression,
                    CreateSearchExpressionFor<TModel>(
                        paramExpression, prop, searchTerm));
            }

            return Expression.Lambda<Func<TModel, bool>>(
                bodyExpression, paramExpression);
        }

        private static Expression CreateOrElseExpression(
            Expression left, Expression right) =>
            Expression.OrElse(left, right);

        private static Expression CreateSearchExpressionFor<TModel>(
            ParameterExpression parameterExpression,
            PropertyInfo property,
            string searchTerm)
            where TModel : IQueryModel
        {
            var propertyType = property.PropertyType;

            searchTerm = searchTerm.ToUpper();

            if (propertyType.Equals(typeof(string)))
            {
                return CreateToUpperContainsExpressionFor<TModel>(
                    parameterExpression, property.Name, searchTerm);
            }

            // Only string search support atm
            throw new NotImplementedException();
        }

        private static Expression CreateToUpperContainsExpressionFor<TModel>(
            ParameterExpression parameterExpression,
            string propertyName,
            string upperCaseSearchTerm)
            where TModel : IQueryModel
        {
            var containsMethod = typeof(string)
                .GetMethod(nameof(string.Contains), new[] { typeof(string) });
            var toUpperMethod = typeof(string)
                .GetMethod(nameof(string.ToUpper), new Type[] { });
            var searchTermValue = Expression.Constant(
                upperCaseSearchTerm, typeof(string));

            var propertyExpression = Expression.Property(
                parameterExpression, propertyName);
            var propertyToUpperExpression =
                Expression.Call(propertyExpression, toUpperMethod);

            return Expression.Call(
                propertyToUpperExpression,
                containsMethod,
                searchTermValue);
        }

        internal static IEnumerable<string>
            GetPropertyNamesThatAllowSort<TModel>()
            where TModel : IQueryModel =>
            GetPublicPropertyNamesWithAttribute<
                TModel, AllowSortAttribute>();

        internal static IEnumerable<string>
            GetPropertyNamesThatAllowSearch<TModel>()
            where TModel : IQueryModel =>
            GetPublicPropertyNamesWithAttribute<
                TModel, AllowSearchAttribute>();

        private static IEnumerable<string>
            GetPublicPropertyNamesWithAttribute<TModel, TAttribute>()
            where TModel : IQueryModel
            where TAttribute : Attribute =>
            typeof(TModel)
                .GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p
                    .GetCustomAttributes<TAttribute>(true).Any())
                .Select(p => p.Name)
                .ToList();
    }
}
