namespace iTechArt.ManagementDemo.Querying.Sort
{
    public interface ISortOptions
    {
        string PropertyName { get; }
        SortDirection SortDirection { get; }
    }
}
