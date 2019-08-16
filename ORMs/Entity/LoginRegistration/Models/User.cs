using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
namespace LoginRegistration.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required]
        [MinLength(2, ErrorMessage="First name must be 2 or more characters")]
        [Display(Name = "First Name")]
        public string FirstName {get;set;}
        [Required]
        [MinLength(2, ErrorMessage="Last name must be 2 or more characters")]
        [Display(Name = "Last Name")]
        public string LastName {get;set;}
        // [EmailAddress]
        [Required(ErrorMessage = "Email cannot be blank")]
        public string Email {get;set;}
        // [DataType(DataType.Password)]
        [Required]
        [MinLength(8, ErrorMessage="Password must be 8 characters or longer!")]
        public string Password {get;set;}

        [NotMapped]
        [Compare("Password")]
        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }

     public class LoginUser
    {
        [EmailAddress]
        [Required]
        [Display(Name="Email")]
        public string EmailAttempt {get;set;}
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string PasswordAttempt {get;set;}
    }
}