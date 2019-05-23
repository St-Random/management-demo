using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Attributes;
using iTechArt.ManagementDemo.Web.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace iTechArt.ManagementDemo.Web.Models.Table
{
    // Far from ideal, but I am tired from refactoring
    public class SearchTableViewModel<TModel> : ISearchTableViewModel
        where TModel : IQueryModel
    {
        public Type ModelType => typeof(TModel);
        public string DataUrl { get; }
        public string NavigationUrl { get; }


        public SearchTableViewModel(
            string dataUrl, string navigationUrl)
        {
            DataUrl = dataUrl;
            NavigationUrl = navigationUrl;
        }


        public IEnumerable<KeyValuePair<string, string>> GetSearchColumns() =>
            ModelType
                .GetProperties(
                    BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop
                    .HasAttribute<AllowSearchAttribute>())
                .Select(prop =>
                    KeyValuePair.Create(
                        prop.Name,
                        prop.GetCustomAttribute<DisplayInfoAttribute>()
                            ?.Name ?? prop.Name));

        public IEnumerable<TableEntry> GetTableEntries()
        {
            var properties = ModelType
                .GetProperties(
                    BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop.HasAttribute<DisplayInfoAttribute>());

            var entries = new List<TableEntry>();
            var groupEntries = new Dictionary<string, ColumnGroupEntry>();

            foreach (var prop in properties)
            {
                var displayInfo = prop
                    .GetCustomAttribute<DisplayInfoAttribute>();
                var columnEntry = GetColumnEntryFor(prop, displayInfo);

                if (string.IsNullOrEmpty(displayInfo.Group))
                {
                    entries.Add(columnEntry);
                }
                else
                {
                    var groupEntry =
                        groupEntries.GetValueOrDefault(displayInfo.Group);

                    if (groupEntry == null)
                    {
                        groupEntry =
                            new ColumnGroupEntry
                            {
                                Title = displayInfo.Group
                            };

                        groupEntries.Add(groupEntry.Title, groupEntry);
                        entries.Add(groupEntry);
                    }

                    groupEntry.Columns.Add(columnEntry);
                }
              
            }

            return entries;
        }

        private ColumnEntry GetColumnEntryFor(
            PropertyInfo prop, DisplayInfoAttribute displayInfo) =>
                new ColumnEntry
                {
                    Field = prop.Name.ToCamelCase(),
                    Title = displayInfo.Name ?? prop.Name,
                    HeaderSort = prop
                        .HasAttribute<AllowSortAttribute>(),
                    Formatter = GetPropertyFormatter(prop),
                    Visible = displayInfo.IsVisible
                };

        private string GetPropertyFormatter(PropertyInfo prop)
        {
            var type = prop.GetType();

            if (type.IsAssignableFrom(typeof(bool))
                || type.IsAssignableFrom(typeof(bool?)))
            {
                return "tickCross";
            }

            if (type.IsAssignableFrom(typeof(DateTime))
                || type.IsAssignableFrom(typeof(DateTime?)))
            {
                return "datetime";
            }

            if (type.IsAssignableFrom(typeof(decimal))
                || type.IsAssignableFrom(typeof(decimal?)))
            {
                return "money";
            }

            return "plaintext";
        }
    }
}
