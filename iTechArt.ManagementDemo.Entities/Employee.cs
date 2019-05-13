using iTechArt.ManagementDemo.Entities.Abstractions;
using iTechArt.ManagementDemo.Entities.Annotations;
using System;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Entities
{
    [MinEmploymentAge(0)] // One should not discriminate against children
    public class Employee : Entity
    {
        [Required]
        [MaxLength(255)]
        public string FirstName { get; set; }

        [MaxLength(255)]
        public string MiddleInitial { get; set; }

        [MaxLength(255)]
        public string LastName { get; set; }

        [MaxLength(255)]
        public string Patronymic { get; set; }

        public Sex Sex { get; set; }

        [MaxLength(255)]
        public string Gender { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(255)]
        public string PhoneNumber { get; set; }

        [MaxLength(255)]
        public string Skype { get; set; }

        [UtcDate]
        [DateInPast]
        public DateTime? DateOfBirth { get; set; }

        [UtcDate]
        public DateTime? DateOfEmployment { get; set; }

        [MaxLength(255)]
        public string Position { get; set; }

        [Range(typeof(decimal), "0.01", "10000000000")]
        public decimal? SalaryInUSD { get; set; }

        public bool? IsMarried { get; set; }

        public bool? HasChildren { get; set; }

        [MaxLength(255)]
        public string Comment { get; set; }

        public int LocationId { get; set; }

        public virtual Location Location { get; set; }

    }
}
