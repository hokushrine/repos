using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BeltExam2.Models
{
    public class DojoActivity
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Title { get; set; }
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime PlannedDate { get; set; }
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Time)]
        public TimeSpan Duration { get; set; }
        [DataType(DataType.Time)]
        public DateTime EndTime { get; set; }
        public string Description{ get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        // Associations
        public User Creator { get; set; }
        public List<AssociatedActivity> AttendingUsers { get; set; }
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