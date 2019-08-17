using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class HomeController : Controller
    {
        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        private WallContext _dbContext;
        public HomeController(WallContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("user/create")]
        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
                if(_dbContext.Users.Any(o => o.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already exists");
                    return View("Index");
                }

                // hash the user's password before saving
                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                
                _dbContext.Add(newUser);
                _dbContext.SaveChanges();

                UserSession = newUser.Id;
                return RedirectToAction("Index", "Message");
            }
            return RedirectToAction("Index");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser returningUser)
        {
            if(ModelState.IsValid)
            {
                // create existing user var that compares existing vs returning user emails
                User existingUser = _dbContext.Users.FirstOrDefault(u => u.Email == returningUser.EmailAttempt);
                if(existingUser is null)
                {
                    ModelState.AddModelError("Email", "Invalid Email/Password");
                    return View("Index", "Home");
                }

                //check stored vs submitted password
                PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
                var result = hasher.VerifyHashedPassword(returningUser, existingUser.Password, returningUser.PasswordAttempt);
                if( result == PasswordVerificationResult.Failed)
                {
                    ModelState.AddModelError("Password", "Invalid Email/Password");
                    return View("Index", "Home");
                }

                UserSession = existingUser.Id;
                return RedirectToAction("Index", "Message");
            }
            return RedirectToAction("Index", "Home");
        }

        [HttpGet("logout")]
        public RedirectToActionResult Logout()
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
