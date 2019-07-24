using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace DojoSurvey.Controllers
{
    public class SurveyController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet("results")]
        public IActionResult Results()
        {
            return View();
        }

        [HttpPost]
        [Route("ResultPost")]
        public IActionResult ResultPost(string name, string favorite, string location)
        {
            ViewBag.name = name;
            ViewBag.location = location;
            ViewBag.favorite = favorite;

            System.Console.WriteLine("TEST");
            System.Console.WriteLine($"Name: {name}\nLoc: {location}\nFav: {favorite}");
            return View("Results");
        }
    }
}