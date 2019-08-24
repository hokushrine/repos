using System.Collections.Generic;
namespace BeltExam2.Models
{
    public class DashboardViewModel
    {
        public List<AssociatedActivity> Attendees {get; set; }
        public List <DojoActivity> UpcomingActivities = new List<DojoActivity>();
    }
}