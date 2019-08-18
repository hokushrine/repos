using Microsoft.AspNetCore.Mvc;

namespace E_CommerceNoStripe
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View("ProductIndex");
        }

        [HttpPost("product/create")]
        public IActionResult Create()
        {
            return RedirectToAction("Index", "Product");
        }
    }
}