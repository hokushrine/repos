using System.Net;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BeltExam3.Models;

namespace BeltExam3.Controllers
{
    public class LikeController : Controller
    {
        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
        private BeltContext _dbContext;
        public LikeController(BeltContext context)
        {
            _dbContext = context;
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == HttpContext.Session.GetInt32("UserId")); }
        } 
        
        public IActionResult AddLike(int ideaId)
        {
            if(ModelState.IsValid)
            {
                var newLike = new Like()
                {
                    UserId = loggedInUser.Id,
                    IdeaId = ideaId
                };

                // get current idea id
                var currentIdeaId = _dbContext.Likes.Where(u => u.IdeaId == newLike.IdeaId).FirstOrDefault(u => u.UserId == UserSession);
                if(currentIdeaId != null)
                {
                    return RedirectToAction("Index", "Idea");
                }
                
                _dbContext.Likes.Add(newLike);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("Index", "Idea");
        }
    }
}