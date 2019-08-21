using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserDashboard.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
        public bool IsAdmin { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public string FullName => $"{FirstName} {LastName}";

        // Associations
        public List<Message> Messages { get; set; }
        public List<Comment> Comments { get; set; }
    }

    public class LoginUser
    {
        [Required]
        public string EmailAttempt { get; set; }
        [Required]
        public string PasswordAttempt { get; set; }
    }

}