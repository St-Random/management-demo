using System.Collections.Generic;

namespace iTechArt.ManagementDemo.Querying.Search
{
    public interface ISearchOptions
    {
        IEnumerable<string> PropertyNames { get; }
        string Term { get; }
    }
}
