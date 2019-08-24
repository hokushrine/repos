// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Http;
// using System.Linq;
// using BeltExam2.Models;

// namespace BeltExam2.Controllers
// {
//     public class AssociatedActivities : Controller
//     {
//         private BeltContext _dbContext;
//         public AssociatedActivitiesController(BeltContext context)
//         {
//             _dbContext = context;
//         }
//         public int? UserSession
//         {
//             get { return HttpContext.Session.GetInt32("UserId"); }
//             set {  HttpContext.Session.SetInt32("UserId", (int)value); }
//         }

//         private User loggedInUser
//         {
//             get { return _dbContext.Users.FirstOrDefault(u => u.Id == UserSession); }
//         }

//         // ** Join and Leave Activities
//         // TODO: Refactor so that the method can be used on Show and Index and checks if the user has already joined
//         public IActionResult Join(int dojoActivityId)
//         {
//             var newAttendee = new AssociatedActivity()
//             {
//                 UserID = loggedInUser.Id,
//                 DojoActivityId = dojoActivityId
//             };
//             _dbContext.AssociatedActivities.Add(newAttendee);
//             _dbContext.SaveChanges();
//             return RedirectToAction("Index");
//         }
//     }
// }


