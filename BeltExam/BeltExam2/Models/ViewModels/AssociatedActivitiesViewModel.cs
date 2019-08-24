using System.Collections.Generic;
namespace BeltExam2.Models
{
    public class AssociatedActivitiesViewModel
    {
        public DojoActivity SelectedDojoActivity { get; set; }
        public List <AssociatedActivity> Attendees = new List<AssociatedActivity>();
    }
}