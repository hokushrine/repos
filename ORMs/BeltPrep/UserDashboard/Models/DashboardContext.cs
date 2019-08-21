using Microsoft.EntityFrameworkCore;
using UserDashboard.Models;

namespace UserDashboard
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Comment> Comments { get; set; }
        
    }
}