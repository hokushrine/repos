using Microsoft.EntityFrameworkCore;

namespace E_CommerceNoStripe.Models
{
    public class EcomContext : DbContext
    {
        public EcomContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}