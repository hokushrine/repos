using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureLogReg.Models;

namespace SecureLogReg.Controllers
{
    public class HomeController : Controller
    {
        private LogRegContext _context;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public HomeController(
            LogRegContext context,
            UserManager<User> userManager,
            SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create(User model)
        {
            if(ModelState.IsValid)
            {
                //Create a new User object, without adding a Password
                User NewUser = new User { UserName = model.UserName, Email = model.Email };
                //CreateAsync will attempt to create the User in the database, simultaneously hashing the
                //password
                IdentityResult result = await _userManager.CreateAsync(NewUser, model.PasswordHash);
                //If the User was added to the database successfully
                if(result.Succeeded)
                {
                    //Sign In the newly created User
                    //We're using the SignInManager, not the UserManager!
                    await _signInManager.SignInAsync(NewUser, isPersistent: false);
                }
                //If the creation failed, add the errors to the View Model
                foreach( var error in result.Errors )
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Logout(LoginUser model)
        {
            await _userManager.FindByEmailAsync(model.Email);
            return RedirectToAction("Success");
        }
        public async Task<IActionResult> Logout(User model)
        {
            await _signInManager.SignInAsync(model, isPersistent: false);
            return RedirectToAction("Success");
        }

        public IActionResult Success()
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
