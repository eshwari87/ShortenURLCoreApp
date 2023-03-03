using System;
using System.Linq;
using System.Web;
    using System.ComponentModel.DataAnnotations;
namespace ShortenURLCoreApp.Models

{

    public class UrlModel

    {

        [Required(ErrorMessage = "Please enter url to shorten")]
        [RegularExpression("http(s)?://([\\w-]+\\.)+[\\w-]+(/[\\w- ./?%&amp;=]*)?", ErrorMessage = "Please enter valid url")]
        [Display(Name = "Enter URL to shorten")]
        [Url(ErrorMessage = "Please enter valid url")]
        public string UrlName { get; set; } = string.Empty;
        public string ShortenUrl { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string DomainName { get; set; } = string.Empty;

        [Key]
        public int urlID { get; set; }
    }


    
}
