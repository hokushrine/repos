using System.Linq;
using Microsoft.AspNetCore.Mvc;
using UserDashboard.Models;

namespace UserDashboard
{
    [Area("Admin")]
    [Route("admin")]
    public class AdminController : Controller
    {
        private DashboardContext _dbContext;
        public AdminController(DashboardContext context)
        {
            _dbContext = context;
        }
        public IActionResult Index()
        {
            var allUsers = _dbContext.Users.ToList();
            var vm = new UserViewModel();
            vm.allUsers = allUsers;
            return View(vm);
        }
    }
}