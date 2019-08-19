using System.Linq;
using E_CommerceNoStripe.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace E_CommerceNoStripe
{
    public class OrderController : Controller
    {
        private EcomContext _dbContext;
        public OrderController(EcomContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var allProducts =  _dbContext.Products.ToList();
            var allCustomers = _dbContext.Customers.ToList();
            var allOrders = _dbContext.Orders.ToList();
            OrderViewModel vm = new OrderViewModel();
            vm.Customers = allCustomers;
            vm.Products = allProducts;
            vm.Orders = allOrders;
                    
            return View("OrderIndex", vm);
        }

        [HttpPost("order/create")]
        public IActionResult Create(OrderViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                var newOrder = modelData.NewOrder;
                // query the db for the quantity of the product
                var existingQuantity = _dbContext.Products.SingleOrDefault(prod => prod.Id == newOrder.ProductId);
                // System.Console.WriteLine(new string('*', 50));
                // System.Console.WriteLine($"prodId: {newOrder.ProductId}");
                // System.Console.WriteLine($"prod name: {existingQuantity.Name}");
                // System.Console.WriteLine($"neworder quant: {newOrder.Quantity}");f
                existingQuantity.Quantity -= newOrder.Quantity;
                // System.Console.WriteLine($"prod quant in db: {existingQuantity.Quantity}");
                _dbContext.Add(newOrder);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Order");
            }
            return View("Index", "Order");
        }
    }
}