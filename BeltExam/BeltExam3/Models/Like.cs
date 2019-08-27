using System;
using System.ComponentModel.DataAnnotations;
using BeltExam3.Models;

namespace BeltExam3.Models
{
    public class Like
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int IdeaId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Nav properties
        public User Creator { get; set; }
        public Idea LikedIdea { get; set; }
    }
}