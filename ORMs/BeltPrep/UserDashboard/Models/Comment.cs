using System;
using System.ComponentModel.DataAnnotations;

namespace UserDashboard
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public int MsgId { get; set; }
        [Required]
        public string CommentBody { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Associations
        public User Creator { get; set; }
        public Message Msg { get; set; }
    }
}