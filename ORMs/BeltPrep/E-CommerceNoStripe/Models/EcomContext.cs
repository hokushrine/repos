using Microsoft.EntityFrameworkCore;

namespace E_CommerceNoStripe.Models
{
    public class EcomContext : DbContext
    {
        public EcomContext(DbContextOptions options) : base(options) { }
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Order> Orders { get; set; }
    }
}