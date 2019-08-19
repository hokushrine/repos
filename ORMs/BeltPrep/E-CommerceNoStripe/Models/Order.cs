using System;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceNoStripe.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0, 1000, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Quantity { get; set; }
        public int CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        // Nav properties
        public Customer Customer { get; set; }
        public Product Product { get; set; }
    }
}