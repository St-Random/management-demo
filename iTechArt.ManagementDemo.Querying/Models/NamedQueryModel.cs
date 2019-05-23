using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Attributes;

namespace iTechArt.ManagementDemo.Querying.Models
{
    public class NamedQueryModel : IQueryModel
    {
        public int Id { get; set; }

        [DisplayInfo("Name")]
        public string Name { get; set; }
    }
}
