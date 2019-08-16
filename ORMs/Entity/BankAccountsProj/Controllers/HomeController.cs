using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BankAccountsProj.Models;

namespace BankAccountsProj.Controllers
{
    public class HomeController : Controller
    {

        private int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        private BankAccountContext _dbContext;
        public HomeController(BankAccountContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

    [HttpPost("Register")]
       public IActionResult CreateUser(User newUser)
       {
           if(ModelState.IsValid)
           {
               PasswordHasher<User> Hasher = new PasswordHasher<User>();
               newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
               _dbContext.Add(newUser);
               _dbContext.SaveChanges();
               return RedirectToAction("GetLogin");
           }
           return View("Index");
       }

       [HttpGet("Login")]
       public IActionResult GetLogin()
       {
           return View("Login");
       }

       [HttpPost("Login")]
       public IActionResult Login(LoginUser returningUser)
       {
           if (ModelState.IsValid)
            {
                // Make sure email is in db
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == returningUser.EmailAttempt);
                if (existingUser == null)
                {
                    // Create error if email not in db
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                // Compare given password to password in db
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(returningUser, existingUser.Password, returningUser.PasswordAttempt);
                if (result == 0)
                {
                    // Create error if passwords don't match
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Login");
                }
                UserSession = existingUser.UserId;
                return RedirectToAction("Index", "Bank");
           }
           return RedirectToAction("GetLogin");
       }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
