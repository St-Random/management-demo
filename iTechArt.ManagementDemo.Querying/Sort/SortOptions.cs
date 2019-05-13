namespace iTechArt.ManagementDemo.Querying.Sort
{
    public class SortOptions : ISortOptions
    {
        public string PropertyName { get; set; }

        public SortDirection SortDirection { get; set; }
    }
}
