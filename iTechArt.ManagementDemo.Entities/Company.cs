using iTechArt.ManagementDemo.Entities.Abstractions;
using iTechArt.ManagementDemo.Entities.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Entities
{
    public class Company : Entity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [MaxLength(255)]
        public string CompanyCode { get; set; }

        [UtcDate]
        [DateInPast]
        public DateTime? DateFounded { get; set; }

        [EmailAddress]
        [MaxLength(255)]
        public string Email { get; set; }

        [Phone]
        [MaxLength(255)]
        public string Phone { get; set; }

        [Phone]
        [MaxLength(255)]
        public string Fax { get; set; }

        [MaxLength(255)]
        public string Comment { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
