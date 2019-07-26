using System.ComponentModel.DataAnnotations;

namespace SimpleLoginRegistration.Models
{
    public class LogUser
    {
        [Required]
        [Display(Name="Email")]
        [EmailAddress]
        public string LogEmail {get; set;}

        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        public string LogPassword{get; set;}
    }
}