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
        public string Name { get; set; }

        [AllowSort]
        [AllowSearch]
        public string CompanyCode { get; set; }

        [AllowSort]
        public DateTime? DateFounded { get; set; }

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
        public int LocationsCount { get; set; }

        [AllowSort]
        public int EmployeesCount { get; set; }
    }
}
