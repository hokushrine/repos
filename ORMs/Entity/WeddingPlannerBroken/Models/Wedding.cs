using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        public int WeddingId { get; set; }
        [Required]
        [Display(Name = "Wedder One")]
        public string WedderOne { get; set; }
        [Required]
        [Display(Name = "Wedder Two")]
        public string WedderTwo { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get ; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public int UserId { get; set; }
        public User Planner { get; set; }
        public List<Response> Responses { get; set; }

        public string ToBeWed
        {
            get { return $"{WedderOne} & {WedderTwo}";}
        }   
    }
}