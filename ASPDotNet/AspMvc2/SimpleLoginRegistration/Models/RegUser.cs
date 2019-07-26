using System.ComponentModel.DataAnnotations;

namespace SimpleLoginRegistration.Models
{
    public class RegUser
    {
        [Required]
        [Display(Name="First Name")]
        public string FirstName {get; set;}

        [Required]
        [Display(Name="Last Name")]
        public string LastName {get; set;}

        [Required]
        [EmailAddress]
        public string Email {get; set;}

        [Required]
        [MinLength(8, ErrorMessage="Cannot be less than 8 characters")]
        [DataType(DataType.Password)]
        public string Password{get; set;}

        [Required]
        [Display(Name="Password Confirmation")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage="Passwords must match")]
        public string PasswordConfirmation {get; set;}

    }
}