using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChefsNDishes.Models;

namespace ChefsNDishes.Controllers
{
    public class HomeController : Controller
    {
        private CnDContext _dbContext;

        public HomeController(CnDContext context)
        {
            _dbContext = context;
        }
        
        [HttpGet("")]
        public IActionResult Index() // using index instead of chef.cshtml
        {
            List<Chef> chefs = _dbContext.Chefs
            // populates each Dish with its related Chef object (Creator)
            .Include(dish => dish.CreatedDishes)
            .ToList();
    
            return View(chefs);
        }

        
        [HttpGet("Dishes")]
        public IActionResult ShowDishes()
        {
            List<Dish> dishesWithChef = _dbContext.Dishes
            // populates each Dish with its related Chef object (Creator)
            .Include(dish => dish.Creator)
            .ToList();
            return View("Dishes", dishesWithChef);
        }

        [HttpGet("New")]
        public IActionResult NewChef()
        {
            return View();
        }

        [HttpPost("Create")]
        public IActionResult CreateChef(Chef newChef)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Chefs.Add(newChef);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("New");
        }

        [HttpGet("dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.AllChefs = _dbContext.Chefs;
            return View();
        }

        [HttpPost("dishes/create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Dishes.Add(newDish);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("NewDish");
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
