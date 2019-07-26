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

        [HttpPost("surveyForm")]
        public IActionResult ResultPost(SurveyModel mySurvey)
        {
            if(ModelState.IsValid)
            {
                return RedirectToAction("results", mySurvey);
            }
            return View("index");
        }
    }
}