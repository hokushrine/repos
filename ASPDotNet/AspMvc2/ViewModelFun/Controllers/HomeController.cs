using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        public List<User> GenerateUsers()
        {
            return new List<User>()
            {
                new User(){ FirstName="Markus", LastName="Harrison"},
                new User(){ FirstName="Ricky", LastName="Ricardo"},
                new User(){ FirstName="Sally", LastName="Squirrel"},
                new User(){ FirstName="James", LastName="Capistrono"},
            };
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            string stringModel = "a really long string being used as a model";
            return View("Index", stringModel);
        }

        [HttpGet("users")]
        public IActionResult Users()
        {
            var users = GenerateUsers();
            return View(users);
        }

        [HttpGet("user")]
        public IActionResult User()
        {
            User someUser = new User()
            {
              FirstName = "Sally",
              LastName = "Sanderson"
            };
            return View(someUser);
        }

        [HttpGet("numbers")]
        public IActionResult Numbers()
        {
            int[] numbers = new int[]{4, 2, 980, -2, 1, 32, -30};
            return View(numbers);
        }
    }
}