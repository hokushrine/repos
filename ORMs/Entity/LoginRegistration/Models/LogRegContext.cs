using Microsoft.EntityFrameworkCore;
namespace LoginRegistration.Models
{
    public class LogRegContext : DbContext
    {
        public LogRegContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users {get;set;}
    }
}