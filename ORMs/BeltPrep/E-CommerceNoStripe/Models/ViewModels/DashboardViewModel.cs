using System.Collections.Generic;
using E_CommerceNoStripe.Models;

namespace E_CommerceNoStripe
{
    public class DashboardViewModel
    {
        public List<Product> Products = new List<Product>();
        public List<Order> Orders = new List<Order>();
        public List<Customer> Customers = new List<Customer>();
    }
}