using iTechArt.ManagementDemo.Web.Infrastructure.Binding;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Web.Models
{
    [Display(Name = "Company")]
    public class CompanyModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Company Code")]
        [DisplayFormat(NullDisplayText = "N/A")]
        public string CompanyCode { get; set; }

        [Display(Name = "Date Founded (UTC)")]
        [DisplayFormat(NullDisplayText = "N/A")]
        [UtcBinder]
        public DateTime? DateFounded { get; set; }

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
    }
}
