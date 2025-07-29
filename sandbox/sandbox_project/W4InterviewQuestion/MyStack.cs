public class MyStack
{
    private readonly MyLinkedList _list = new MyLinkedList();

    public void Push(int num)
    {
        _list.InsertHead(num);
    }

    public int Pop()
    {
        return _list.RemoveHead();
    }

    public int GetTop()
    {
        return _list.GetHeadData();
    }

    public bool IsEmpty()
    {
        return _list.HeadAndTailAreNull();
    }

}