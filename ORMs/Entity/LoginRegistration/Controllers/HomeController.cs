using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using LoginRegistration.Models;

namespace LoginRegistration.Controllers
{
    public class HomeController : Controller
    {
        private LogRegContext dbContext;
        
        public HomeController(LogRegContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            List<User> AllUsers = dbContext.Users.ToList();
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
                 if(dbContext.Users.Any(o => o.Email == newUser.Email))
                {
                    ModelState.AddModelError("Email", "Email already in use");
                    return View("Index");
                }

                PasswordHasher<User> hasher = new PasswordHasher<User>();
                newUser.Password = hasher.HashPassword(newUser, newUser.Password);

                dbContext.Users.Add(newUser);
                dbContext.SaveChanges();
                return RedirectToAction("Success");
            }
            return RedirectToAction("Index");
        }
        
        [HttpGet("Success")]
        public IActionResult Success()
        {
            ViewData["Message"] = "Success Page";
            System.Console.WriteLine("=======================================================");
            System.Console.WriteLine("CURRENT SESSION: ", HttpContext.Session.GetInt32("userId"));
            if(HttpContext.Session.GetInt32("userId") == null)
                return RedirectToAction("Index");

            return View();
        }

        [HttpGet("login")]
        public IActionResult Login()
        {
            
            return View("Login");
        }

        [HttpPost("login")]
        public IActionResult Login(LoginUser returningUser)
        {
            User toLogin = dbContext.Users.FirstOrDefault(u => u.Email == returningUser.EmailAttempt);
            if(toLogin == null)
            {
                ModelState.AddModelError("EmailAttempt", "Invalid Email/Password");
                return View("Login");
            }
            PasswordHasher<LoginUser> hasher = new PasswordHasher<LoginUser>();
            var result = hasher.VerifyHashedPassword(returningUser, toLogin.Password, returningUser.PasswordAttempt);
            if(result == PasswordVerificationResult.Failed)
            {
                ModelState.AddModelError("EmailAttempt", "Invalid Email/Password");
                return View("Login");
            }
            // Log user into session
            HttpContext.Session.SetInt32("userId", toLogin.UserId);
            return RedirectToAction("Success");
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
