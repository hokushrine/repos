using System.Collections.Generic;
using TheWall.Models;

namespace TheWall
{
    public class WrapperModel
    {
        public Message Message { get; set; }
        public Comment Comment { get; set; }
        public List<Message> Messages { get; set; }
        public List<Comment> Comments { get; set; }
    }
}