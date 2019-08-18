using Microsoft.AspNetCore.Mvc;

namespace E_CommerceNoStripe
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View("OrderIndex");
        }

        [HttpPost("order/create")]
        public IActionResult Create()
        {
            return RedirectToAction("Index", "Order");
        }
    }
}