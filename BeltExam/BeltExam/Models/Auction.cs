using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BeltExam.Models;

namespace BeltExam.Models
{
    public class Auction
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Bid { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int StartingBid { get; set; }
        public int CurrentBid { get; set; }
        public int HighestBid { get; set; }
        [Required]
        public string ProductDesc { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime EndDate { get; set; }
        public bool BidStatus { get; set;} = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Associations
        public User Creator { get; set; }
        public List<BidAssociation> Bidders { get; set; }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(!(value is DateTime))
                return new ValidationResult("Invalid date");
                
            DateTime date = Convert.ToDateTime(value);

            if(date < DateTime.Now)
                return new ValidationResult("Date must be in the future!");

            return ValidationResult.Success;

        }
    }
}