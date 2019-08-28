using System.Collections.Generic;
using BeltExam3.Models;

namespace BeltExam3.Models
{
    public class IdeaViewModel
    {
        public Idea Idea { get; set; }
        public Like Like { get; set; }
        public List<Idea> Ideas { get; set; }
        public List<Like> Likes { get; set; }
    }
}