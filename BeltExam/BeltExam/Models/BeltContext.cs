using Microsoft.EntityFrameworkCore;

namespace BeltExam.Models
{
    public class BeltContext : DbContext
    {
        public BeltContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users { get ; set; }
        public DbSet<Auction> Auctions { get ; set; }
        public DbSet<BidAssociation> Bids { get ; set; }
    }
}