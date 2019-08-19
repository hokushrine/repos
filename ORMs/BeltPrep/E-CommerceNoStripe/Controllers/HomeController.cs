using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using E_CommerceNoStripe.Models;
using Microsoft.EntityFrameworkCore;

namespace E_CommerceNoStripe.Controllers
{
    public class HomeController : Controller
    {
        private EcomContext _dbContext;
        public HomeController(EcomContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var products = _dbContext.Products
            .OrderByDescending(r => r.CreatedAt)
                .Take(10)
                .ToList();
            
            var recentOrders = _dbContext.Orders
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .Include(c => c.Customer)
                .Include(p => p.Product)
                .ToList();
            var newestCustomers = _dbContext.Customers
            .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .ToList();
            DashboardViewModel vm = new DashboardViewModel();
            vm.Customers = newestCustomers;
            vm.Orders = recentOrders;
            vm.Products = products;
            return View(vm);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
