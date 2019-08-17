using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name="Last Name")]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm Password")]
        [MinLength(8, ErrorMessage="Password minimum length is 8 characters")]
        public string Password { get; set; }
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name="Confirm Password")]
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string FullName => $"{FirstName} {LastName}";

        // Associations
        public List<Message> Messages {get; set;}
        public List<Comment> Comments {get; set;}
    }

    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string EmailAttempt { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string PasswordAttempt { get; set; }
    }
}