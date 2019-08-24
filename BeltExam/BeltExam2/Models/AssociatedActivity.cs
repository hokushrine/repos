using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeltExam2.Models;

namespace BeltExam2.Models
{
    public class AssociatedActivity
    {
        [Key]
        public int Id { get; set; }
        public int UserID { get; set; }
        public int DojoActivityId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public User JoinedUser { get; set; }
        // public DojoActivity JoinedActivity { get; set; }
    }
}