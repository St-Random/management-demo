using iTechArt.ManagementDemo.Querying.Abstractions;
using iTechArt.ManagementDemo.Querying.Attributes;
using System;

namespace iTechArt.ManagementDemo.Querying.Models
{
    public class LocationEmployeeModel : IQueryModel
    {
        public int Id { get; set; }

        [AllowSort]
        [AllowSearch]
        public string FirstName { get; set; }

        [AllowSort]
        [AllowSearch]
        public string MiddleInitial { get; set; }

        [AllowSort]
        [AllowSearch]
        public string LastName { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Patronymic { get; set; }

        [AllowSort]
        public Sex Sex { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Gender { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Email { get; set; }

        [AllowSort]
        [AllowSearch]
        public string PhoneNumber { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Skype { get; set; }

        [AllowSort]
        public DateTime? DateOfBirth { get; set; }

        [AllowSort]
        public DateTime? DateOfEmployment { get; set; }

        [AllowSort]
        [AllowSearch]
        public string Position { get; set; }

        [AllowSort]
        public decimal? SalaryInUSD { get; set; }

        [AllowSort]
        public bool? IsMarried { get; set; }

        [AllowSort]
        public bool? HasChildren { get; set; }

        [AllowSearch]
        public string Comment { get; set; }
    }
}
