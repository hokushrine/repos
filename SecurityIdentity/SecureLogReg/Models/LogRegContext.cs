using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
//Other usings
namespace SecureLogReg.Models
{
    public class LogRegContext : IdentityDbContext<User>
    {
        //Setup Context as normal
        public LogRegContext(DbContextOptions options) : base(options){}
        public DbSet<User> users { get; set; }
    }
}
