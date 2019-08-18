using System.Collections.Generic;
using E_CommerceNoStripe.Models;

namespace E_CommerceNoStripe
{
    public class ProductViewModel
    {
        public Product NewProduct { get; set; }
        public List<Product> Products = new List<Product>();
    }
}