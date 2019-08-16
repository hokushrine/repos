using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace ChefsNDishes.Models
{
    public class NoFutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if((DateTime) value > DateTime.Now)
            {
                return new ValidationResult("Date must be in the past");
            }
            return ValidationResult.Success;
        }
    }
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}
        [Required]
        public string FirstName {get;set;}
        [Required]
        public string LastName {get;set;}

        [NotMapped]
        [Display(Name = "Chef")]
        public string FullName
        {
            get {return $"{FirstName} {LastName}";}
        }
        [Required]
        [DataType(DataType.Date)]
        [NoFutureDate]
        public DateTime Age {get;set;}
        // Navigation property for related Message objects
        public List<Dish> CreatedDishes {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}