using iTechArt.ManagementDemo.Entities.Abstractions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Entities
{
    public class Location : Entity
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }

        [Required]
        public virtual Address Address { get; set; }

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

        public virtual ICollection<Employee> Employees { get; set; }

        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
    }
}
