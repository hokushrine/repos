using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeltExam3.Models;

namespace BeltExam3
{
    public class Idea
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        [Display(Name="Post an idea!")]
        [MinLength(5, ErrorMessage="Idea must be five characters or more")]
        public string IdeaContent { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Nav properties
        public User Creator { get; set; }
        public List<Like> ReceivedLikes { get; set;}
    }
}