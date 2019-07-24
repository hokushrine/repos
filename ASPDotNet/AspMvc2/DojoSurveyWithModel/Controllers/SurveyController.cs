using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DojoSurveyWithModel.Models;
namespace DojoSurveyWithModel.Controllers
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

        [HttpPost("survey")]
        public IActionResult ResultPost(Survey mySurvey)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("results", mySurvey);
            }
            return View("index");
        }
    }
}