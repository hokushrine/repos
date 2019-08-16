using Microsoft.EntityFrameworkCore;
 
namespace ProductsAndCategories.Models
{
    public class PCContext : DbContext
    {
        // base() calls the parent class' constructor passing the "options" parameter along
        public PCContext(DbContextOptions options) : base(options) { }
        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}
        public DbSet<Association> Associations {get; set;}
    }
}
