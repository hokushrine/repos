using Microsoft.AspNetCore.Mvc;
using FEHClone.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace FEHClone.Controllers
{
    public class AccountController : Controller
    {
        private FehContext _dbContext;
        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == UserSession);}
        }
        public IActionResult Create(User newUser)
        {
            if(ModelState.IsValid)
            {
                PasswordHasher<User> hasher = new PasswordHasher<User>();

                if(!_dbContext.Users.Any())
                {
                    newUser.UserLevel = "Admin";
                    newUser.Password = hasher.HashPassword(newUser, newUser.Password);
                    _dbContext.Add(newUser);
                    _dbContext.SaveChanges();
                    UserSession = newUser.Id;
                    return RedirectToAction("Index", "Home");
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
    }
}