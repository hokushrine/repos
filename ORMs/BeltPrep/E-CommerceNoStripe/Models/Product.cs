using System;
using System.Collections.Generic;

namespace E_CommerceNoStripe.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quanity { get; set; }
        public string Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Order> Orders = new List<Order>();
    }
}