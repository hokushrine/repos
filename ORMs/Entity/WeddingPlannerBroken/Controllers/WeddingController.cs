using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner
{
    public class WeddingController : Controller
    {
        private int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId")); }
        } 

        private WeddingContext _dbContext;
        public WeddingController (WeddingContext context)
        {
            _dbContext = context;
        }

        
        [HttpGet("dashboard")]
        public  IActionResult Index()
        {
            // redirect to register/login page if no session
            // if(loggedInUser == null) { return RedirectToAction("Index", "Home"); }

            var weddings = _dbContext.Weddings
                .Include(w => w.Responses)
                .OrderByDescending(w => w.Date);

            // ViewBag.UserId = loggedInUser.UserId;
            // var responsed = weddings.Where(w => w.Responses.Any(r => r.UserId == 1));


            return View(weddings.ToList());
        }

        [HttpGet("wedding/new")]
        public IActionResult NewWedding()
        {
            return View();
        }

        public IActionResult Create(Wedding newWedding)
        {
            if (UserSession == null)
                    return RedirectToAction("Index", "Home");
            if (ModelState.IsValid)
            {   
                // Crete new wedding with UserId set to current session user's id
                newWedding.UserId = (int)UserSession;
                _dbContext.Weddings.Add(newWedding);
                _dbContext.SaveChanges();
                return RedirectToAction("Dashboard");
            }
            return View("New");
        }

        [HttpGet("{weddingId}")]
        public IActionResult Show(int weddingId)
        {
            var thisWedding = _dbContext.Weddings
            .Include(w => w.Responses)
            .ThenInclude(r => r.Guest)
            .FirstOrDefault(w => w.WeddingId == weddingId);
            return View(thisWedding);
        }

        [HttpGet("delete")]
        public IActionResult Delete(int weddingId)
        {
            if (UserSession == null)
                return RedirectToAction("Index", "Home");

            Wedding toDelete = _dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId);
            
            if (toDelete == null)
                return RedirectToAction("Dashboard");
            // Redirect to dashboard if user trying to delete isn't the wedding creator
            if (toDelete.UserId != UserSession) { return RedirectToAction("Dashboard"); }
            
            _dbContext.Weddings.Remove(toDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Dashboard");
        }
    }
}