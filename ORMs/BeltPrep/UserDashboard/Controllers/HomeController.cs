using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserDashboard.Models;

namespace UserDashboard.Controllers
{
    public class HomeController : Controller
    {
        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
        private DashboardContext _dbContext;
        public HomeController(DashboardContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();

                if(!_dbContext.Users.Any())
                {
                    newUser.IsAdmin = true;
                    newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                    _dbContext.Add(newUser);
                    _dbContext.SaveChanges();
                    UserSession = newUser.Id;
                    return RedirectToAction("Index", "Admin", new {area = "admin"});
                }
                if(_dbContext.Users.Any(o => o.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return View("Index");
                }
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                _dbContext.Add(newUser);
                _dbContext.SaveChanges();
                UserSession = newUser.Id;
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Login(LoginUser returningUser)
        {
            if(ModelState.IsValid)
            {
                // check if the user is in the db
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == returningUser.EmailAttempt);
                if(existingUser is null)
                {
                    // Create error if email is not in db
                    ModelState.AddModelError("Email", "Email/Password is invalid");
                    return View("Index");
                }
                // Compare given password to password in db
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(returningUser, existingUser.Password, returningUser.PasswordAttempt);
                if(result == 0)
                {
                    // Create error if password mismatch
                    ModelState.AddModelError("Password", "Email/Password is invalid");
                    return View("Index");
                }
                UserSession = existingUser.Id;
                if(existingUser.IsAdmin)
                {
                    return RedirectToAction("Index", "Admin", new {area = "admin"});
                }
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpGet("dashboard")]
        public IActionResult Dashboard()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
