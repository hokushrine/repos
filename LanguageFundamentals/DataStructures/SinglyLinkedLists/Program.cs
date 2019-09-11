using System;

namespace SinglyLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
         LinkedList list = new LinkedList();
         list.Append(4);
        //  list.IsEmpty();
         list.Append(6);
         list.Append(34);
        //  list.RemoveAt(list, 6);
         list.Append(675);
        //  list.RemoveLast();
        //  list.FindNode(34);
        //  list.Swap(1, 5);
        //  list.RemoveFirst();
         list.PrintAllNodes();
        //  System.Console.WriteLine($"There are {list.Count()} nodes in the list.");
        //  list.Append(53);
        //  list.Remove();
        //  System.Console.WriteLine("After removal");
        //  list.PrintAll();
        }
    }
}
