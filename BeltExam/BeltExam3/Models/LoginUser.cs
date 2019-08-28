using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BeltExam3.Models;

namespace BeltExam3
{
    public class LoginUser
    {
        [Required]
        [EmailAddress]
        [Display(Name="Email")]
        public string EmailAttempt { get; set; }
        [Required]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string PasswordAttempt { get; set; }
    }
}