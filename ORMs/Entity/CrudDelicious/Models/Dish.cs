using System.ComponentModel.DataAnnotations;
using System;
namespace CrudDelicious.Models
{
    public class Dish
    {
        // auto-implemented properties need to match the columns in your table
        // the [Key] attribute is used to mark the Model property being used for your table's Primary Key
        [Key]
        public int DishID { get; set; }
        // MySQL VARCHAR and TEXT types can be represeted by a string

        [Required]
        public string Name { get; set; }
        [Required]
        public string Chef { get; set; }
        
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int Calories { get; set; }

        [Required]
        [Range(0, 5, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Tastiness {get; set;}
        public string Description {get; set;}
        // The MySQL DATETIME type can be represented by a DateTime
        public DateTime CreatedAt {get;set;}
        public DateTime UpdatedAt {get;set;}
    }
}
