using System.Diagnostics;

public class NodeBst
{
    public int Data { get; set; }
    public NodeBst? Right { get; private set; }
    public NodeBst? Left { get; private set; }

    public NodeBst(int data)
    {
        this.Data = data;
    }

    public void Insert(int value)
    {
        // TODO Start Problem 1
        if (value < Data)
        {
            // Insert to the left
            if (Left is null)
                Left = new NodeBst(value);
            else
                Left.Insert(value);
        }
        else if (value > Data)
        {
            // Insert to the right
            if (Right is null)
                Right = new NodeBst(value);
            else
                Right.Insert(value);
        }
        else
        {
            Debug.WriteLine("This value yet exist in tree");
        }
    }

    public bool Contains(int value)
    {
        if (value < Data)
        {
            if (Left is null)
            {
                return false;
            }
            else
            {
                return Left.Contains(value);
            }
        }
        else if (value > Data)
        {
            if (Right is null)
            {
                return false;
            }
            else
            {
                return Right.Contains(value);
            }
        }
        else
        {
            return true;
        }
    }

    public int GetHeight()
    {
        int heightLeft = 1;
        int heightRight = 1;

        if (Right is not null)
        {
            heightRight = Right.GetHeight() + heightRight;
        }

        if (Left is not null)
        {
            heightLeft = Left.GetHeight() + heightLeft;
        }

        if (heightRight > heightLeft)
        {
            return heightRight;
        }
        else
        {
            return heightLeft;
        }
    }
}