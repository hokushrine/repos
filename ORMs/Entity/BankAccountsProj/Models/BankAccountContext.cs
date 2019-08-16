using Microsoft.EntityFrameworkCore;

namespace BankAccountsProj.Models
{
    public class BankAccountContext : DbContext
    {
        public BankAccountContext(DbContextOptions options) : base(options) {}
        public DbSet<User> Users {get;set;}
        public DbSet<Transaction> Transactions {get;set;}
    }
}