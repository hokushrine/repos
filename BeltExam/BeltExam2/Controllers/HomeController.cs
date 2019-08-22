using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using BeltExam2.Models;

namespace BeltExam2.Controllers
{
    public class HomeController : Controller
    {
        private BeltContext _dbContext;
        public HomeController(BeltContext context)
        {
            _dbContext = context;
        }

        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set {  HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == UserSession); }
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
                // Check if email is already in use
                if(_dbContext.Users.Any(o => o.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return View("Index");
                }
                // Check if Username is already in use
                if(_dbContext.Users.Any(o => o.Username == newUser.Username))
                {
                    ModelState.AddModelError("Username", "Username already in use");
                    return View("Index");
                }
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                _dbContext.Add(newUser);
                _dbContext.SaveChanges();
                UserSession = newUser.Id;
                return RedirectToAction("Index", "Auction");
            }
            return View("Index");
        }

        public IActionResult Login(LoginUser returningUser)
        {
            if(ModelState.IsValid)
            {
                // Check if the email is in the db
                var existingUser = _dbContext.Users.FirstOrDefault(u => u.Username == returningUser.UsernameAttempt);
                if(existingUser is null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index");
                }
                // Compare given password to password in db
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(returningUser, existingUser.Password, returningUser.PasswordAttempt);
                if(result == 0)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Index");
                }
                UserSession = existingUser.Id;
                return RedirectToAction("Index", "Auction");
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
