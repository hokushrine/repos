using System;
namespace SinglyLinkedLists
{
    
    class LinkedList
    {
        Node head;

        public void Append(int data)
        {
            if(head == null)
            {
                head = new Node(data);
                return;
            }
            Node current = head;
            while(current.next != null)
            {
                current = current.next;
            }
            current.next = new Node(data);
        }

        public void Remove()
        {
            Node current = head;
            if(head == null) { return; }
            while(current.next != null)
            {
                if(current.next.next != null) // if the next node of the next node is null (two nodes ahead)
                {
                    current.next = null; // set the next node to null
                }
            }
        }

        public void PrintAll()
        {
            Node current = head;
            // while(current.next != null)
            // {
            //     Console.WriteLine(head.data);
            //     current = current.next;
            //     Console.WriteLine(current.data);
            // }
            Node tempNode = this.head;
            while (tempNode != null) 
            {
                Console.WriteLine(tempNode.data + "->");
                tempNode = tempNode.next;
            }
        }
    }
}