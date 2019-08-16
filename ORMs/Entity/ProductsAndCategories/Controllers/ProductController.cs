using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers.Products
{
    public class ProductController : Controller
    {
        private PCContext _dbContext;
        public ProductController(PCContext context)
        {
            _dbContext = context;
        }
        [HttpGet("products")]
        public IActionResult Index()
        {
            List<Product> x = _dbContext.Products.ToList();
            return View("ProductIndex", x);
        }

        [HttpPost("create/product")]
        public IActionResult Create(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                _dbContext.Products.Add(newProduct);
                _dbContext.SaveChanges();
            }
            ViewBag.AllProducts = newProduct;
            System.Console.WriteLine("=========================================================");
            System.Console.WriteLine(ViewBag.AllProducts);
            return RedirectToAction("ProductIndex");
        }

        [HttpGet("{productId}")]
        public IActionResult Show(int productId)
        {
            var pModel = _dbContext.Products
                .Include(p => p.Associations)
                .ThenInclude(a => a.Category)
                .FirstOrDefault(p => p.ProductId == productId);
            
            // All/Any
            var unrelatedCategories = _dbContext.Categories
                .Include(c => c.Associations)
                .Where(c => c.Associations.All(a => a.ProductId != productId));

            // value of most expensive
            float mostExpensiveValue = _dbContext.Products.Max(pr => pr.Price);

            // find most expensive product
            Product mostExpensive = _dbContext.Products
                .FirstOrDefault(p => p.Price == mostExpensiveValue);

            // find first category that is associated with the most expensive product
            Category associatedToMostExpensive = _dbContext.Categories
                .Include(c => c.Associations)
                .ThenInclude(a => a.Product)
                .FirstOrDefault(c => c.Associations.Any(a => a.Product.Price == mostExpensiveValue));
            ViewBag.Categories = unrelatedCategories;
            return View(pModel);
        }

        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
