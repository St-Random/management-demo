using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Entities
{
    public class Address
    {
        [Required]
        [MaxLength(255)]
        public string Country { get; set; }

        // Area or County
        [Required]
        [MaxLength(255)]
        public string Area { get; set; }

        // City or town
        [Required]
        [MaxLength(255)]
        public string City { get; set; }

        [Required]
        [MaxLength(255)]
        public string AddressLine1 { get; set; }

        [MaxLength(255)]
        public string AddressLine2 { get; set; }

        // They can actually be alphanumeric, if I remember correctly o_O
        [Required]
        [MaxLength(255)]
        public string PostalCode { get; set; }
    }
}
