using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheWall.Models
{
    public class Message
    {
        public int id { get; set; }
        [Required]
        public string MessageBody { get; set; }
        public int UserId { get; set; }

        // Associations
        public User Creator { get; set; }
        public List<Comment> Comments { get; set; }
    }
}