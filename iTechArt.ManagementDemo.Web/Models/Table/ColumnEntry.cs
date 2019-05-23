namespace iTechArt.ManagementDemo.Web.Models.Table
{
    public class ColumnEntry : TableEntry
    {
        public string Field { get; set; }
        public string Formatter { get; set; }
        public bool Visible { get; set; }
        public bool HeaderSort { get; set; }
    }
}
