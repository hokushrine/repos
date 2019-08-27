using Microsoft.EntityFrameworkCore;
using FEHClone.Models;

namespace FEHClone.Models
{
    public class FehContext : DbContext
    {
        public FehContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Heros {get; set; }
        public DbSet<User> Skills {get; set; }
        public DbSet<User> Users {get; set; }
        public DbSet<User> Weapons {get; set; }
        public DbSet<User> CommandSkills {get; set; }
        public DbSet<User> SpecialSkills {get; set; }
    }
}