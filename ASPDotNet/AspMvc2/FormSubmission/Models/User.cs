using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4, ErrorMessage="First name must be 4 or more characters")]
        [Display(Name = "First Name: ")]
        public string FirstName {get; set;}

        [Required]
        [MinLength(4, ErrorMessage="First name must be 4 or more characters")]
        [Display(Name="Last Name")]
        public string LastName {get; set;}

        [Required]
        [Range(0, 150, ErrorMessage="Age must be a positive number")]
        public int Age {get; set;}

        [Required]
        [EmailAddress]
        [Display(Name="Email Address")]
        public string Email {get; set;}

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password minimum length is 8 characters")]
        public string Password {get; set;}
    }
}