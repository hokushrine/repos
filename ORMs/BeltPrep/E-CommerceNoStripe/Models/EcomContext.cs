using Microsoft.EntityFrameworkCore;

namespace E_CommerceNoStripe.Models
{
    public class EcomContext : DbContext
    {
        public EcomContext(DbContextOptions options) : base(options) { }
    }
}