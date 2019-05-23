using System.Collections.Generic;

namespace iTechArt.ManagementDemo.Web.Models.Table
{
    public class ColumnGroupEntry : TableEntry
    {
        public IList<ColumnEntry> Columns { get; set; } =
            new List<ColumnEntry>();
    }
}
