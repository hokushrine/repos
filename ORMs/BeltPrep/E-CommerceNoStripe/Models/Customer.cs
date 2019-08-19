using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace E_CommerceNoStripe.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        List<Order> Orders = new List<Order>();
    }
}