using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string CommentBody { get; set; }
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Associations
        public User Creator { get; set; }
        public Message Message { get; set; }
    }
}