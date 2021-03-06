using Microsoft.EntityFrameworkCore;

namespace BeltExam2.Models
{
    public class BeltContext : DbContext
    {
        public BeltContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users { get ; set; }
        public DbSet<DojoActivity> DojoActivitiesDb { get ; set; }
        public DbSet<AssociatedActivity> AssociatedActivities { get ; set; }
    }
}