using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class MessageController : Controller
    {
        public int? UserSession
        {
            get { return HttpContext.Session.GetInt32("UserId"); }
            set { HttpContext.Session.SetInt32("UserId", (int)value); }
        }
        private WallContext _dbContext;
        public MessageController(WallContext context)
        {
            _dbContext = context;
        }

        private User loggedInUser
        {
            get { return _dbContext.Users.FirstOrDefault(u => u.Id == HttpContext.Session.GetInt32("UserId")); }
        } 
        public IActionResult Index()
        {
            if(UserSession is null)
            {
                return RedirectToAction("Index", "Home");
            }

            var allMessages = _dbContext.Messages
                .Include(u => u.Creator)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            var allComments = _dbContext.Comments
                .Include(m => m.Message)
                .Include(u => u.Creator)
                .OrderByDescending(m => m.CreatedAt)
                .ToList();

            WrapperModel wrapper = new WrapperModel();
            wrapper.Messages = allMessages;
            wrapper.Comments = allComments;
            return View(wrapper);
        }

        [HttpPost("message/create")]
        public IActionResult Create(WrapperModel modelData)
        {
            if(ModelState.IsValid)
            {
                Message newMsg = modelData.Message;
                newMsg.UserId = loggedInUser.Id;
                _dbContext.Add(newMsg);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Message");
            }
            return View("Index");
        }
    }
}