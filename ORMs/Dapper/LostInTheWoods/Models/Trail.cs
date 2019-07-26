using System.ComponentModel.DataAnnotations;

namespace LostInTheWoods.Models
{
    public class Trail
    {
        [Key]
        public long Id {get; set;}

        [Required]
        public  string Name {get; set;}

        [Required]
        public string Description {get; set;}

        [Required]
        public int Length {get; set;}
        
        [Required]
        public int ElevationChange {get; set;}
        
        [Required]
        public int Longitude {get; set;}
        
        [Required]
        public int Latitutde {get; set;}
    }
}