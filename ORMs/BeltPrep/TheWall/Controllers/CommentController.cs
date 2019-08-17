using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class CommentController : Controller
    {
        private WallContext _dbContext;
        public CommentController(WallContext context)
        {
            _dbContext = context;
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == HttpContext.Session.GetInt32("UserId")); }
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("NewComment");
        }

        [HttpPost("create")]
        public IActionResult Create(WrapperModel modelData)
        {
            if(ModelState.IsValid)
            {
                Comment newComment = modelData.Comment;
                newComment.UserId = loggedInUser.Id;
                _dbContext.Add(newComment);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Message");
            }
            return View("Index", "Message");
        }
    }
}