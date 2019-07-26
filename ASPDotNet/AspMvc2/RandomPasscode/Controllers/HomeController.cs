using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        public string GeneratePasscode(int len)
        {
            Random rand = new Random();
            string values = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
            string result = "";
            for(var i = 0; i < len; i++)
            {
                result += values[rand.Next(values.Length)];
            }
            return result;
        }
        
        [HttpGet("")]
        public IActionResult Index()
        {
            // if(HttpContext.Session.GetString("passcode") == null)
            HttpContext.Session.SetString("test", "aasdfasf");
            HttpContext.Session.SetInt32("testint", 4);
            // {
            //     HttpContext.Session.SetString("passcode", "Generate a Passcode!");
            // }

            // int? times = HttpContext.Session.GetInt32("times");
            // if (times is null)
            // {
            //     times = HttpContext.Session.SetInt32("times",0);
            // }
            // times = HttpContext.Session.GetInt32("times");
            // System.Console.WriteLine(times);

            ViewBag.Msg = HttpContext.Session.GetString("test");
            ViewBag.MsgInt = HttpContext.Session.GetInt32("testint");
            // ViewBag.Passcode = HttpContext.Session.GetString("passcode");
            // ViewBag.Times = HttpContext.Session.GetInt32("times");
            return View();
        }

        [HttpGet("new")]
        public IActionResult NewPasscode()
        {
            System.Console.WriteLine("Times before getting in /new: ", HttpContext.Session.GetInt32("testint"));
            // int? times = HttpContext.Session.GetInt32("testint");
            // times++;
            // System.Console.WriteLine("Times: ", times);
            // HttpContext.Session.SetInt32("times", (int)times);
            ViewBag.Passcode = HttpContext.Session.SetString("passcode", GeneratePasscode(14));
            return RedirectToAction("Index");
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
