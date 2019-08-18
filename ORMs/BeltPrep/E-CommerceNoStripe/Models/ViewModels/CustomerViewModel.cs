using System.Collections.Generic;
using E_CommerceNoStripe.Models;

namespace E_CommerceNoStripe
{
    public class CustomerViewModel
    {
        public Customer NewCustomer { get; set; }
        public List<Customer> Customers = new List<Customer>();
    }
}