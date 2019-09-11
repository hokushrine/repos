using System.Transactions;
using System.Runtime.InteropServices;
using System.Collections.Generic;
namespace SinglyLinkedLists
{

    // TODO: Refactor to actually use pointers
    public class LinkedList
    {
        public Node Head;
        public LinkedList()
        {
            Head = null;
        }

/*
 
           __  __ _____ _____ _   _  ___  ____  ____  
          |  \/  | ____|_   _| | | |/ _ \|  _ \/ ___| 
          | |\/| |  _|   | | | |_| | | | | | | \___ \ 
          | |  | | |___  | | |  _  | |_| | |_| |___) |
          |_|  |_|_____| |_| |_| |_|\___/|____/|____/ 
                                                      
 
*/
        #region Append
        public void Append(int data)
        {
            if(Head == null)
            {
            Head = new Node(data);
            //  IsEmpty = false;
            } else {
            Node newNode = new Node(data);
            // Head = newNode;
            Node current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
            }
        }
        #endregion
        #region InsertAt
        public void InsertAt(int toInsert)
        {

        }
        #endregion
        #region FindNode
        /// <summary>
        /// Returns the index of a node's given value
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
            public int FindNode(int key)
            {
                if(Head == null)
                {
                    System.Console.WriteLine("The list is empty");
                    return -1;
                } else {
                    int index = 0;
                    Node current = Head;
                    // Iterate till the last element until key is not found
                    while(current != null && current.Data != key)
                    {
                        index++;
                        current = current.Next;
                    }
                    System.Console.WriteLine(index);
                    return (current !=null) ? index: -1;
                }
            }
        #endregion
        #region PrintAllNodes
        public void PrintAllNodes()
        {
            if(Head == null)
            {
                System.Console.WriteLine("The list is empty");
                return;
            }
            Node current = Head;
            while (current.Next != null)
            {
                System.Console.Write($"{current.Data} -> ");
                current = current.Next;
            }
            if(current.Next == null) { System.Console.WriteLine(current.Data); }
        }
        #endregion
        #region RemoveFirst
        public void RemoveFirst()
        {
            if(Head == null)
            {
                System.Console.WriteLine("The list is empty");
            } else {
                if(Head.Next == null)
                {
                    System.Console.WriteLine($"{Head.Data} has been removed");
                    Head = null;
                }
                else if(Head.Next != null)
                {
                    System.Console.WriteLine($"{Head.Data} has been removed");
                    Head = Head.Next;
                }
            }
        }
        #endregion
        #region RemoveLast
            public void RemoveLast()
            {
                Node current = Head;
                while(current.Next.Next != null)
                {
                    current = current.Next;
                }
                current.Next = null;
            }
        #endregion
        #region RemoveNodeAt
        /// <summary>
        ///     Removes the node of choice from the selected list
        /// </summary>
        /// <param name="list"></param>
        /// <param name="toRemove"></param>
        /// <returns name="list"></returns>
        public LinkedList RemoveAt(LinkedList list, int toRemove)
        {
            if(list.IsEmpty())
            {
                return list;
            } else {
            // Traverse the list until the first node with the matching value is found
                int counter = 0;
                Node current = Head;
                if (toRemove == 0)
                {
                    Head = current.Next;
                    return list;
                }
                while (counter != toRemove -1)
                {
                    if (current.Next == null)
                    {
                        System.Console.WriteLine("Index is out of list bounds.");
                        return list;
                    }
                    counter++;
                    current = current.Next;
                }
                current.Next = current.Next.Next;
                return list;
            }
        }
        #endregion
        #region Swap (Incomplete)

            // public void Swap(int pos1, int pos2)
            // {
            //     if(Head == null)
            //     {
            //         System.Console.WriteLine("The list is empty");
            //         return;
            //     }
            //     else if(pos1 == pos2){
            //         System.Console.WriteLine("Swap targets cannot match");
            //         return;
            //     } else {
            //         Node current = Head.Next;
            //         Node prev = Head;
            //         int swap1Data;
            //         int swap2Data;
            //         // traverse to target 1 and 2 and store their data
            //         // ! What if one of the positions is the last node? .Next will be null and unreachable
            //         while(current.Next != null)
            //         {
            //             if(current.Next.Data == pos1)
            //             {
            //                 swap1Data = (int)current.Next.Data;
            //                 current = current.Next;
            //             }
            //             if(current.Next.Data == pos2)
            //             {
            //                 swap2Data = (int)current.Next.Data;
            //             } else {
            //                 current = current.Next;
            //             }
            //         }
                    // check the last node
                    // if(prev.Next.Data == pos1)
                    // {
                    //     swap1Data = (int)current.Next.Data;
                    // }
                    // else if(prev.Next.Data == pos2)
                    // {
                    //     swap2Data = (int)current.Next.Data;
                    // }
                    // // set current to head again and traverse to set the nodes
                    // current = Head;
                    // while(current.Next != null)
                    // {

                    // }
                    // return;
                // }

            // }
        #endregion

/*

           _   _      _                    __                  _   _
          | | | | ___| |_ __   ___ _ __   / _|_   _ _ __   ___| |_(_) ___  _ __  ___
          | |_| |/ _ \ | '_ \ / _ \ '__| | |_| | | | '_ \ / __| __| |/ _ \| '_ \/ __|
          |  _  |  __/ | |_) |  __/ |    |  _| |_| | | | | (__| |_| | (_) | | | \__ \
          |_| |_|\___|_| .__/ \___|_|    |_|  \__,_|_| |_|\___|\__|_|\___/|_| |_|___/
                       |_|

*/
        #region Helper functions

        public bool IsEmpty()
        {
            if(Head != null)
            {
                return false;
            } else {
                System.Console.WriteLine("The list is empty");
                return true;
            }
        }
        /// <summary>
        /// Returns the count of all nodes in the list
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            if(Head == null)
            {
                System.Console.WriteLine("The list is empty");
                return -1;
            } else {
                Node current = Head;
                int count = 1;
                while(current.Next != null)
                {
                    count++;
                    current = current.Next;
                }
                return count;
            }
        }
    }
        #endregion
}