using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        public int WeddingId {get;set;}
        public string Groom {get;set;}
        public string Bride {get;set;}
        // Must Be Future Date
        [DataType(DataType.Date)]
        [FutureDate]
        public DateTime Date {get;set;}
        public string Address {get;set;}
        public int UserId {get;set;}
        public User Planner {get;set;}
        public List<Response> Responses {get;set;}
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