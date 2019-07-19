using System;
using System.Collections.Generic;
using System.Linq;

namespace BoxingUnboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> boxList = new List<object>();
            List<int> intlist = new List<int>();

            boxList.Add(7);
            boxList.Add(28);
            boxList.Add(-1);
            boxList.Add(true);
            boxList.Add("chair");

            foreach (var item in boxList)
            {
                Console.WriteLine(item);

                if (item is int)
                {
                    var x = Convert.ToInt32(item);
                    intlist.Add(x);
                }
            }

            Console.Write("Sum of ints: ");
            Console.WriteLine(intlist.Sum());
        }
    }
}
