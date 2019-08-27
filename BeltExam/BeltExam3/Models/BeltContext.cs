using Microsoft.EntityFrameworkCore;
using BeltExam3.Models;

namespace BeltExam3.Models
{
    public class BeltContext : DbContext
    {
        public BeltContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Idea> Ideas { get; set; }
        public DbSet<Like> Likes { get; set; }
        
    }
}