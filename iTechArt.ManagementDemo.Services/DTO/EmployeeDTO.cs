using System;

namespace iTechArt.ManagementDemo.Services.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleInitial { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public Sex Sex { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Skype { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public DateTime? DateOfEmployment { get; set; }
        public string Position { get; set; }
        public decimal? SalaryInUSD { get; set; }
        public bool? IsMarried { get; set; }
        public bool? HasChildren { get; set; }
        public string Comment { get; set; }

        public int LocationId { get; set; }
        public string LocationName { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
    }
}
