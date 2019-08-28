using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeltExam3.Models;

namespace BeltExam3.Controllers
{
    public class IdeaController : Controller
    {
        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
        private BeltContext _dbContext;
        public IdeaController(BeltContext context)
        {
            _dbContext = context;
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == HttpContext.Session.GetInt32("UserId")); }
        } 
        [HttpGet("bright_ideas")]
        public IActionResult Index()
        {
            if(UserSession is null)
            {
                return RedirectToAction("Index", "Home");
            }

            var allIdeas = _dbContext.Ideas
                .Include(u => u.Creator)
                .Include(likes => likes.ReceivedLikes)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            var allLikes = _dbContext.Likes
                .Include(i => i.LikedIdea)
                .Include(u => u.Creator)
                .ToList();

            IdeaViewModel vm = new IdeaViewModel();
            vm.Ideas = allIdeas;
            ViewBag.UserId = loggedInUser.Id;
            return View("Index", vm);
        }

        [HttpPost("idea/create")]
        public IActionResult Create(IdeaViewModel modelData)
        {
            if(ModelState.IsValid)
            {
                Idea newIdea = modelData.Idea;
                newIdea.UserId = loggedInUser.Id;

                _dbContext.Add(newIdea);
                _dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            ModelState.AddModelError("Idea", "Idea cannot be blank");
            // Index is expecting this data and will complain without it
            var allIdeas = _dbContext.Ideas
                .Include(u => u.Creator)
                .Include(likes => likes.ReceivedLikes)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            var allLikes = _dbContext.Likes
                .Include(i => i.LikedIdea)
                .Include(u => u.Creator)
                .ToList();

            IdeaViewModel vm = new IdeaViewModel();
            vm.Ideas = allIdeas;
            return View("Index", vm);
            // return RedirectToAction("Index");
        }
        [HttpGet("ideas/{IdeaId}")]
        public IActionResult Show(int ideaId)
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}
            
             var singleIdea = _dbContext.Ideas
                .Include(c => c.Creator)
                .Include(p => p.ReceivedLikes)
                .FirstOrDefault(p => p.Id == ideaId);

            var allLikes = _dbContext.Likes
                .Include(a => a.Creator)
                .OrderByDescending(d => d.CreatedAt).ToList();
            
            var vm = new SingleIdeaVM();
            vm.Idea = singleIdea;
            vm.Likes = allLikes;
            return View(vm);
        }

        [HttpGet("remove/{IdeaId}")]
        public IActionResult Delete(int ideaId)
        {
            if(loggedInUser == null) {return RedirectToAction("Index", "Home");}

            // query for activity
            Idea toDelete = _dbContext.Ideas.FirstOrDefault(w => w.Id == ideaId
                && w.UserId == loggedInUser.Id);
            
            // if null, redirect
            if(toDelete == null) {return RedirectToAction("Index");}
            
            _dbContext.Ideas.Remove(toDelete);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}