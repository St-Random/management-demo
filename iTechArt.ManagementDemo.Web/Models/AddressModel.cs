using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Web.Models
{
    public class AddressModel
    {
        [Display(Name = "Country")]
        public string Country { get; set; }

        // Area or County
        [Display(Name = "Area or County")]
        public string Area { get; set; }

        // City or town
        [Display(Name = "City or Town")]
        public string City { get; set; }

        [Display(Name = "Address line 1")]
        public string AddressLine1 { get; set; }

        [Display(Name = "Address line 2")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string AddressLine2 { get; set; }

        [Display(Name = "Postal code")]
        public string PostalCode { get; set; }
    }
}
