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
    }
}