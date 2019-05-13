using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Attributes;

namespace iTechArt.ManagementDemo.Querying.Models
{
    public class CompanyLocationModel : IQueryModel
    {
        public int Id { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Name { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Email { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Phone { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Fax { get; set; }

        [AllowSearch]
        public string Comment { get; set; }

        [AllowSort]
        [AllowSearch]
        public int EmployeesCount { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Country { get; set; }

        // Area or County
        [AllowSort]
        [AllowSearch]
        public string Area { get; set; }

        // City or town
        [AllowSort]
        [AllowSearch]
        public string City { get; set; }

        [AllowSort]
        [AllowSearch]
        public string PostalCode { get; set; }
    }
}
