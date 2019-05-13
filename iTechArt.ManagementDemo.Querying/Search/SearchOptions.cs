using System.Collections.Generic;

namespace iTechArt.ManagementDemo.Querying.Search
{
    public class SearchOptions : ISearchOptions
    {
        public IEnumerable<string> PropertyNames { get; set; }

        public string Term { get; set; }
    }
}
