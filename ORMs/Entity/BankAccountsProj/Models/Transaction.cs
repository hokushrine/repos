using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountsProj.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionId {get; set;}
        public decimal Amount {get; set;}
        public int UserId {get; set;}
        public User Creator {get; set;}
        public DateTime CreatedAt {get; set;} = DateTime.Now;
    }
}