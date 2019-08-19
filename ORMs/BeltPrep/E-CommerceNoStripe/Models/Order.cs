using System;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceNoStripe.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
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