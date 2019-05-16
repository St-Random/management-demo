using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Web.Models
{
    public enum Sex
    {
        [Display(Name = "Unspecified")]
        Unspecified = 0,

        [Display(Name = "Female")]
        Female = 1,

        [Display(Name = "Male")]
        Male = 2
    }
}
