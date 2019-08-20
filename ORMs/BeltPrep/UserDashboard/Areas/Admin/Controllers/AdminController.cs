using Microsoft.AspNetCore.Mvc;

namespace UserDashboard
{
    [Area("Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View("Index", "Admin");
        }
    }
}