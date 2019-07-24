using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace TimeDisplay.Controllers
{
    public class TimeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            
            return View("Index");
        }
    }
}