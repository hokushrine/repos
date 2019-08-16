using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers.Categories
{
    public class CategoryController : Controller
    {
        private PCContext _dbContext;
        public CategoryController(PCContext context)
        {
            _dbContext = context;
        }
        [HttpGet("Categories")]
        public IActionResult Index()
        {
            ViewBag.AllCategories = _dbContext.Categories;
            return View("CategoryIndex");
        }

        [HttpPost("create")]
        public IActionResult Create(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Categories.Add(newCategory);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AllCategories = _dbContext.Categories;
            return View("Index");
        }
    }
}