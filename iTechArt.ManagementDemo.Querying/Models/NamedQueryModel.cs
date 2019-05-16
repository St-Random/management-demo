using iTechArt.ManagementDemo.Querying.Abstractions;

namespace iTechArt.ManagementDemo.Querying.Models
{
    public class NamedQueryModel : IQueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
