namespace iTechArt.ManagementDemo.Querying.Pagination
{
    public interface IPaginationOptions
    {
        int Page { get; }
        int ItemsPerPage { get; }
    }
}
