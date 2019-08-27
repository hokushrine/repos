using System.Collections.Generic;
using BeltExam3.Models;

namespace BeltExam3.Models
{
    public class SingleIdeaVM
    {
        public Idea Idea { get; set; }
        public List<Like> Likes { get; set; }
    }
}