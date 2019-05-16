using System.ComponentModel.DataAnnotations;

namespace iTechArt.ManagementDemo.Web.Models
{
    public class ErrorViewModel
    {
        [Display(Name = "Request Id")]
        public string RequestId { get; set; }

        [Display(Name = "Error Message")]
        public string Message { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}