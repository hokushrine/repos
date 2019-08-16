using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccountsProj.Models
{
    public class User
    {
      [Key]
      public int UserId {get; set;}
      [Required]
      public string FirstName {get; set;}
      [Required]
      public string LastName {get; set;}
      [Required]
      public string Email {get; set;}
      [Required]
      public string Password {get; set;}
      [NotMapped]
      public string ConfirmPassword {get; set;}
      public List<Transaction> UserTransactions {get;set;}
      public DateTime CreatedAt {get; set;} = DateTime.Now;
      public DateTime UpdatedAt {get; set;} = DateTime.Now;
    }

     public class LoginUser
    {
        [EmailAddress]
        [Required]
        [Display(Name="Email")]
        [NotMapped]
        public string EmailAttempt {get;set;}
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        [NotMapped]
        public string PasswordAttempt {get;set;}
    }

}