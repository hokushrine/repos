using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlowPost
{
    class Post
    {
        // create properties
        private string _title;
        private string _description;
        private DateTime _timeCreated;

        // keep track of vote total
        private int _voteCount;

        // Post constructor
        public Post(string title, string description, DateTime timeCreated)
        {
            this._title = title;
            this._description = description;
            this._timeCreated = timeCreated;
            this._voteCount = 0;

        }
        
        public void Upvote()
        {
            _voteCount++;
        }
        
        public void Downvote()
        {
            _voteCount--;
        }

        // getters
        public string GetTitle() { return _title; }
        public string GetDescription() { return _description; }
        public DateTime GetTimeCreated() { return _timeCreated; }
        }
        

        public static void DisplayPost(Post post)
        {
            Console.WriteLine(
                "Title: {0}" +
                "Description: {1}" +
                "Time Created: {2}" +
                "Vote Count: {3}",
                post._title, post._description, post._timeCreated, post._voteCount
            );
        }

    }
}
