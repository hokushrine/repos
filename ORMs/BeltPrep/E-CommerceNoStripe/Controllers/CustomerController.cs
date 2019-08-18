using E_CommerceNoStripe.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_CommerceNoStripe
{
    public class CustomerController : Controller
    {
        private EcomContext _dbContext;
        public CustomerController(EcomContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            return View("CustomerIndex");
        }

        [HttpPost("customer/create")]
        public IActionResult Create(CustomerViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                Customer newCustomer = modelData.NewCustomer;

                _dbContext.Add(newCustomer);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Customer");
        }
    }
}