using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BeltExam3.Models;

namespace BeltExam3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z ]+$", ErrorMessage="Name must contain letters only")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage="Alias can contain letters or numbers")]
        public string Alias { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [Display(Name="Password")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage="Password must be 8 characters or more")]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password")]
        [Display(Name="Confirm Password")]
        [DataType(DataType.Password)]
        
        public string ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Associations
        public List<Idea> PostedIdeas { get; set;}
        public List<Like> GivenLikes { get; set;}
    }


    
}