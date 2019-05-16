using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Web.Models
{
    [Display(Name = "Employee")]
    public class EmployeeModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Initial")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string MiddleInitial { get; set; }

        [Display(Name = "Last Name")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string LastName { get; set; }

        [Display(Name = "Patronymic")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Patronymic { get; set; }

        [Display(Name = "Sex")]
        public Sex Sex { get; set; }

        [Display(Name = "Gender")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Gender { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [Phone]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Skype")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Skype { get; set; }

        [Display(Name = "Date of Birth")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Date of Employment")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public DateTime? DateOfEmployment { get; set; }

        [Display(Name = "Position")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Position { get; set; }

        [Display(Name = "Salary, $")]
        [DisplayFormat(
            DataFormatString = "{0:C}",
            NullDisplayText = "N/A",
            ApplyFormatInEditMode = true)]
        public decimal? SalaryInUSD { get; set; }

        [Display(Name = "Is Married")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public bool? IsMarried { get; set; }

        [Display(Name = "Have Children")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public bool? HasChildren { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Comment { get; set; }

        [HiddenInput]
        public int LocationId { get; set; }

        [Display(Name = "Location")]
        public string LocationName { get; set; }

        [HiddenInput]
        public int CompanyId { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }
    }
}
