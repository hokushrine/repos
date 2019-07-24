public class SinglyLinkedList
{
    public SllNode Head;
    public SinglyLinkedList() 
    {
        Head = null;
    }

    public SinglyLinkedList(SllNode head)
    {
        Head = head;
    }

    // SLL methods go here. As a starter, we will show you how to add a node to the list.
    public void Add(int val) 
    {
        SllNode newNode = new SllNode(val);
        if(Head == null) 
        {
            Head = newNode;
        } 
        else
        {
            SllNode runner = Head;
            while(runner.Next != null) {
                runner = runner.Next;
            }
            runner.Next = newNode;
        }
    }

    public void Remove(int val)
    {

    }

    public void PrintValues()
    {

    }

    // public int Find(int val)
    // {
    //     // int nodeValue = val;
    //     // for(var i = 0; i < val; i++)
    //     // {

    //     // }
    // }
}
