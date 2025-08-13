public class NodeLinkedList
{
    public int Data { get; set; }
    public NodeLinkedList? Next { get; set; }
    public NodeLinkedList? Prev { get; set; }

    public NodeLinkedList(int data)
    {
        this.Data = data;
    }
}