using System.Collections.Generic;
using E_CommerceNoStripe.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceNoStripe
{
    public class OrderViewModel
    {
        public Order NewOrder { get; set; }
        public List<Order> Orders = new List<Order>();
        public List<Customer> Customers = new List<Customer>();
        public List<Product> Products = new List<Product>();
    }
}