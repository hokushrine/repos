using Microsoft.EntityFrameworkCore;

namespace UserDashboard
{
    public class DashboardContext : DbContext
    {
        public DashboardContext(DbContextOptions options) : base(options) { }
        DbSet<User> Users { get; set; }
        DbSet<Message> Messages { get; set; }
        DbSet<Comment> Comments { get; set; }
        
    }
}