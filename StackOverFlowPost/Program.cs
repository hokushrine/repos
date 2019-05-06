using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StackOverFlowPost
{
    class Program
    {
        static void Main(string[] args)
        {
            var post1 = new Post("title1", "description 1", DateTime.Now);
            var post2 = new Post("title2", "description 2", DateTime.Now);

            //DisplayPost(post1);
            post1.Upvote();
            Console.WriteLine(post1.);
        }

        
    }
}
