using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Attributes;
using System;

namespace iTechArt.ManagementDemo.Querying.Models
{
    public class CompanyQueryModel : IQueryModel
    {
        public int Id { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Name")]
        public string Name { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Code")]
        public string CompanyCode { get; set; }

        [AllowSort]
        [DisplayInfo("Date Founded")]
        public DateTime? DateFounded { get; set; }

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
        [DisplayInfo("Locations")]
        public int LocationsCount { get; set; }

        [AllowSort]
        [DisplayInfo("Employees")]
        public int EmployeesCount { get; set; }

        [AllowSearch]
        [DisplayInfo("Comment", IsVisible = false)]
        public string Comment { get; set; }
    }
}
