using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class HomeController : Controller
    {

        private int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        
        
        private WeddingContext _dbContext;
        public HomeController(WeddingContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

       [HttpPost("register")]
       public IActionResult CreateUser(User newUser)
       {
           if(ModelState.IsValid)
           {
               // check for pre-existing user in db
               var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == newUser.Email);
               if (existingUser != null)
               {
                   ModelState.AddModelError("Email", "Email already exists!");
                   return View("Index");
               }

               PasswordHasher<User> Hasher = new PasswordHasher<User>();
               newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
               _dbContext.Users.Add(newUser);
               _dbContext.SaveChanges();
               UserSession = newUser.UserId;
               RedirectToAction("Dashboard", "Wedding");
           }
        return View("Index");
       }

        [HttpPost("login")]
        public IActionResult Login(LoginUser returningUser)
        {
            if(ModelState.IsValid)
            {
                // check if email exists in db
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == returningUser.EmailAttempt);
                if(existingUser == null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }

                // Compare given password to password in db
                var hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(returningUser, existingUser.Password, returningUser.PasswordAttempt);
                if (result == 0)
                {
                    // Create error if passwords don't match
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Index");
                }

                UserSession = existingUser.UserId;
                return RedirectToAction("Dashboard", "Wedding");
            }
            return View("Index");
        }

       public IActionResult Logout()
       {
           HttpContext.Session.Clear();
           return RedirectToAction("Index");
       }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
