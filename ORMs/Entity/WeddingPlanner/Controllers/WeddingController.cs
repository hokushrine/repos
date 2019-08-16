using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using WeddingPlanner.Models;

namespace WeddingPlanner.Controllers
{
    public class WeddingController : Controller
    {
        
        private WeddingContext _dbContext;
        public WeddingController(WeddingContext context)
        {
            _dbContext = context;
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("userId")); }
        } 
        // localhost:5000/weddings
        [HttpGet("dashboard")]
        public IActionResult Index()
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}

            var weddings = _dbContext.Weddings
                .Include(w => w.Responses)
                .OrderByDescending(w => w.Date);

            ViewBag.UserId = loggedInUser.UserId;
            var responded = weddings.Where(w => w.Responses.Any(r => r.UserId == 1));


            return View(weddings.ToList());
        }
        [HttpGet("{weddingId}")]
        public IActionResult Show(int weddingId)
        {
            if(loggedInUser == null)
                return RedirectToAction("Index", "Home");
            
            Wedding viewModel = _dbContext.Weddings
                .Include(w => w.Responses)
                .ThenInclude(r => r.Guest)
                .FirstOrDefault(w => w.WeddingId == weddingId);

            return View(viewModel);

        }
        [HttpPost("create/wedding")]
        public IActionResult Create(Wedding newWedding)
        {
            if(ModelState.IsValid)
            {
                newWedding.UserId = loggedInUser.UserId;
                _dbContext.Weddings.Add(newWedding);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = loggedInUser.UserId;
            return View("New");
        }
        [HttpGet("new")]
        public IActionResult New()
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}

            ViewBag.UserId = loggedInUser.UserId;
            return View();
        }
        [HttpGet("remove/{weddingId}")]
        public IActionResult Remove(int weddingId)
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}

            // query for wedding
            Wedding toDelete = _dbContext.Weddings.FirstOrDefault(w => w.WeddingId == weddingId
                && w.UserId == loggedInUser.UserId);
            
            // if null, redirect
            if(toDelete == null) {return RedirectToAction("Index");}
            
            _dbContext.Weddings.Remove(toDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}