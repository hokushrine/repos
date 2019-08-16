using Microsoft.AspNetCore.Mvc;

namespace TheWall.Controllers
{
    public class MessageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}