using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Attributes;

namespace iTechArt.ManagementDemo.Querying.Models
{
    public class CompanyLocationModel : IQueryModel
    {
        public int Id { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Name")]
        public string Name { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Email", Group = "Contact Info")]
        public string Email { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Phone", Group = "Contact Info")]
        public string Phone { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Fax", Group = "Contact Info")]
        public string Fax { get; set; }

        [AllowSort]
        [DisplayInfo("Employees")]
        public int EmployeesCount { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Country", Group = "Address")]
        public string Country { get; set; }

        // Area or County
        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Area", Group = "Address")]
        public string Area { get; set; }

        // City or town
        [AllowSort]
        [AllowSearch]
        [DisplayInfo("City", Group = "Address")]
        public string City { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Postal Code", Group = "Address")]
        public string PostalCode { get; set; }

        [AllowSearch]
        [DisplayInfo("Comment", IsVisible = false)]
        public string Comment { get; set; }
    }
}
