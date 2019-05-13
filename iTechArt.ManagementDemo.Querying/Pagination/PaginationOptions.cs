namespace iTechArt.ManagementDemo.Querying.Pagination
{
    public class PaginationOptions : IPaginationOptions
    {
        public int Page { get; set; }
        public int ItemsPerPage { get; set; }
    }
}
