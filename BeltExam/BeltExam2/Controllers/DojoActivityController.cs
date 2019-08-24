using System.Net;
using System;
using Microsoft.AspNetCore.Mvc;
using BeltExam2.Controllers;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using BeltExam2.Models;

namespace BeltExam2.Controllers
{
    public class DojoActivityController : Controller
    {
        private BeltContext _dbContext;
        public DojoActivityController(BeltContext context)
        {
            _dbContext = context;
        }
        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set {  HttpContext.Session.SetInt32("UserId", (int)value); }
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == UserSession); }
        }
        [HttpGet("home")]
        public IActionResult Index()
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}
            var allActivities = _dbContext.DojoActivitiesDb
                .Include(p => p.AttendingUsers)
                .Include(c => c.Creator)
                .OrderByDescending(d => d.CreatedAt)
                .ToList();

            DashboardViewModel vm = new DashboardViewModel();
            vm.UpcomingActivities = allActivities;
            ViewBag.UserId = loggedInUser.Id;
            return View(vm);
        }

        // **Get and Create a new Activity
        [HttpGet("new")]
        public IActionResult New()
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}
            return View();
        }
        [HttpPost("new")]
        public IActionResult Create(DojoActivity newActivity)
        {
            newActivity.UserId = loggedInUser.Id;
            if(ModelState.IsValid)
            {
                // Compare StartTime and EndTime
                if(newActivity.EndTime < newActivity.StartTime)
                {
                    ModelState.AddModelError("EndTime", "End time must be greater than start time");
                    return View("New");
                }
                newActivity.Duration = newActivity.EndTime.Subtract(newActivity.StartTime);


                _dbContext.DojoActivitiesDb.Add(newActivity);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }

        // ** Show an activity
        [HttpGet("activity/{DojoActivityId}")]
        public IActionResult Show(int DojoActivityId)
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}
             var singleDojoActivity = _dbContext.DojoActivitiesDb
                .Include(p => p.AttendingUsers)
                .Include(c => c.Creator)
                .FirstOrDefault(p => p.Id == DojoActivityId);
            var allAttendees = _dbContext.AssociatedActivities
                .Include(a => a.JoinedUser)
                .OrderByDescending(d => d.CreatedAt).ToList();
            
            var singleAttendee = loggedInUser;
            var vm = new AssociatedActivitiesViewModel();
            vm.SelectedDojoActivity = singleDojoActivity;
            vm.Attendees = allAttendees;
            return View(vm);
        }

        [HttpGet("remove/{DojoActivityId}")]
        public IActionResult Delete(int dojoActivityId)
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}

            // query for activity
            DojoActivity toDelete = _dbContext.DojoActivitiesDb.FirstOrDefault(w => w.Id == dojoActivityId
                && w.UserId == loggedInUser.Id);
            
            // if null, redirect
            if(toDelete == null) {return RedirectToAction("Index");}
            
            _dbContext.DojoActivitiesDb.Remove(toDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        
        // ** Join and Leave Activities
        // TODO: Refactor so that the method can be used on Show and Index and checks if the user has already joined
        public IActionResult Join(int dojoActivityId)
        {
            var newAttendee = new AssociatedActivity()
            {
                UserID = loggedInUser.Id,
                DojoActivityId = dojoActivityId
            };

            _dbContext.AssociatedActivities.Add(newAttendee);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("leave/{DojoActivityId}")]
        public IActionResult Leave(int dojoActivityId)
        {
            // First get the ID where dojoactivity ids match
            var activityToRemove = _dbContext.AssociatedActivities.Where(u => u.DojoActivityId == dojoActivityId);
            // then do another query on the activityToRemove object that was returned
            //  and check for the first userId matches the UserSession
            var x = activityToRemove.FirstOrDefault(u => u.UserID == UserSession);
            
            if(x != null)
            {
                _dbContext.AssociatedActivities.Remove(x);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}