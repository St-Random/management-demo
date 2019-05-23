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
        [DisplayInfo("First Name", Group = "Name")]
        public string FirstName { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Initial", Group = "Name")]
        public string MiddleInitial { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Last Name", Group = "Name")]
        public string LastName { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Patronymic", Group = "Name")]
        public string Patronymic { get; set; }

        [AllowSort]
        [DisplayInfo("Sex")]
        public Sex Sex { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Gender")]
        public string Gender { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Email", Group = "Contact Info")]
        public string Email { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Phone", Group = "Contact Info")]
        public string PhoneNumber { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Skype", Group = "Contact Info")]
        public string Skype { get; set; }

        [AllowSort]
        [DisplayInfo("DoB")]
        public DateTime? DateOfBirth { get; set; }

        [AllowSort]
        [DisplayInfo("Employment Date", Group = "Employment Info")]
        public DateTime? DateOfEmployment { get; set; }

        [AllowSort]
        [AllowSearch]
        [DisplayInfo("Position", Group = "Employment Info")]
        public string Position { get; set; }

        [AllowSort]
        [DisplayInfo("Salary, $", Group = "Employment Info")]
        public decimal? SalaryInUSD { get; set; }

        [AllowSort]
        [DisplayInfo("Married", Group = "Family Status")]
        public bool? IsMarried { get; set; }

        [AllowSort]
        [DisplayInfo("Has Children", Group = "Family Status")]
        public bool? HasChildren { get; set; }

        [AllowSearch]
        [DisplayInfo("Comment", IsVisible = false)]
        public string Comment { get; set; }
    }
}
