using System;
using System.Collections.Generic;

namespace iTechArt.ManagementDemo.Web.Models.Table
{
    public interface ISearchTableViewModel
    {
        Type ModelType { get; }
        string DataUrl { get; }
        string NavigationUrl { get; }
        IEnumerable<KeyValuePair<string, string>> GetSearchColumns();
        IEnumerable<TableEntry> GetTableEntries();
    }
}
