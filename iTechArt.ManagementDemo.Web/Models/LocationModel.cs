using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Web.Models
{
    [Display(Name = "Location")]
    public class LocationModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Address")]
        public virtual AddressModel Address { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        [Phone]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Phone { get; set; }

        [Display(Name = "Fax")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Fax { get; set; }

        [Display(Name = "Comment")]
        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string Comment { get; set; }

        [HiddenInput]
        public int CompanyId { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }
    }
}
