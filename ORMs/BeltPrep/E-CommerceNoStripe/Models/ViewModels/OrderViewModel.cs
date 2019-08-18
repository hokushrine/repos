using System.Collections.Generic;
using E_CommerceNoStripe.Models;

namespace E_CommerceNoStripe
{
    public class OrderViewModel
    {
        public Order NewOrder { get; set; }
        public List<Order> Orders = new List<Order>();
    }
}