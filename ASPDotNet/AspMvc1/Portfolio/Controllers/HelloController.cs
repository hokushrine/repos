using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace Portfolio.Controllers
{
    public class HelloController : Controller
    {
        // for each route the controller is to handle
        [HttpGet]   // type of request
        [Route("")] // associated route string (exclude the leading /)
        public ViewResult Index()   
        {
            return View();
        }

        [HttpGet("projects")]
        public ViewResult Projects()
        {
            return View();
        }

        [HttpGet("contact")]
        public ViewResult Contact()
        {
            return View();
        }
    }
}