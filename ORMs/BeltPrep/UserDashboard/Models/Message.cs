using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace UserDashboard.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string MessageBody { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Associations
        public User Creator { get; set; }
        public List<Comment> Comments { get ; set; }
    }
}