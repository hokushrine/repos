using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudDelicious.Models;

namespace CrudDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructorcopy
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        public IActionResult Index()
        {
            List<Dish> AllDishs = dbContext.Dishes.ToList();
    
			return View(dbContext.Dishes.OrderByDescending(d => d.CreatedAt));
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult CreateDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }

        [HttpGet("dishID")]
        public IActionResult Show(int dishID)
        {
            Dish model = dbContext.Dishes.FirstOrDefault(d => d.DishID == dishID);
            if(model == null)
                return RedirectToAction("Index");
            return View(model);
        }

        [HttpGet("{dishID}/edit")]
        public IActionResult Edit(int dishID)
        {
             Dish model = dbContext.Dishes.FirstOrDefault(d => d.DishID == dishID);
            if(model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        [HttpPost("{dishId}/update")]
        public IActionResult Update(Dish dish, int dishId)
        {
            Dish toUpdate = dbContext.Dishes.FirstOrDefault(d => d.DishID == dishId);
            if(ModelState.IsValid)
            {
                toUpdate.Name = dish.Name;
                toUpdate.Chef = dish.Chef;
                toUpdate.Tastiness = dish.Tastiness;
                toUpdate.Calories = dish.Calories;
                toUpdate.Description = dish.Description;
                toUpdate.UpdatedAt = DateTime.Now;
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Edit", dish);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
