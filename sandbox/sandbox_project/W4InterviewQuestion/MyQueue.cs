public class MyQueue
{
    private readonly MyLinkedList _list = new MyLinkedList();

    public void Enqueue(int num)
    {
        _list.InsertTail(num);
    }

    public int Dequeue()
    {
        return _list.RemoveHead();
    }

    public int Size()
    {
        return _list.GetSize();
    }

    public bool IsEmpty()
    {
        return _list.HeadAndTailAreNull();
    }
}