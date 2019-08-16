using System;

namespace SinglyLinkedLists
{
    class Program
    {
        static void Main(string[] args)
        {
         LinkedList list = new LinkedList();
         list.Append(4);
         list.Append(6);
         list.Append(34);
         list.Append(675);
         list.Append(53);
         list.PrintAll();
         list.Remove();
         System.Console.WriteLine("After removal");
         list.PrintAll();
        }
    }
}
