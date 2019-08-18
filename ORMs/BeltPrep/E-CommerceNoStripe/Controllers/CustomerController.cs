using Microsoft.AspNetCore.Mvc;

namespace E_CommerceNoStripe
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View("CustomerIndex");
        }

        [HttpPost("customer/create")]
        public IActionResult Create()
        {
            return RedirectToAction("Index", "Customer");
        }
    }
}