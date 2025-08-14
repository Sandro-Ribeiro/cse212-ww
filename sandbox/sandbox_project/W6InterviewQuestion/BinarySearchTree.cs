using System.Collections;

public class BinarySearchTree : IEnumerable<int>
{
    private NodeBst? _root;

    /// <summary>
    /// Insert a new node in the BST.
    /// </summary>
    public void Insert(int value)
    {
        // Create new node
        NodeBst newNode = new NodeBst(value);
        // If the list is empty, then point both head and tail to the new node.
        if (_root is null)
        {
            _root = newNode;
        }
        // If the list is not empty, then only head will be affected.
        else
        {
            _root.Insert(value);
        }
    }

    /// <summary>
    /// Check to see if the tree contains a certain value
    /// </summary>
    /// <param name="value">The value to look for</param>
    /// <returns>true if found, otherwise false</returns>
    public bool Contains(int value)
    {
        return _root != null && _root.Contains(value);
    }

    /// <summary>
    /// Yields all values in the tree
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        // call the generic version of the method
        return GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the BST
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var numbers = new List<int>();
        TraverseForward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseForward(NodeBst? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseForward(node.Left, values);
            values.Add(node.Data);
            TraverseForward(node.Right, values);
        }
    }

    /// <summary>
    /// Iterate backward through the BST.
    /// </summary>
    public IEnumerable Reverse()
    {
        var numbers = new List<int>();
        TraverseBackward(_root, numbers);
        foreach (var number in numbers)
        {
            yield return number;
        }
    }

    private void TraverseBackward(NodeBst? node, List<int> values)
    {
        if (node is not null)
        {
            TraverseBackward(node.Right, values);
            values.Add(node.Data);
            TraverseBackward(node.Left, values);
        }
    }

    /// <summary>
    /// Get the height of the tree
    /// </summary>
    public int GetHeight()
    {
        if (_root is null)
            return 0;
        return _root.GetHeight();
    }

    public override string ToString()
    {
        return "<Bst>{" + string.Join(", ", this) + "}";

    }

    /// <summary>
    /// Public function that the user calls to start the validation.
    /// </summary>
    /// <returns>True if the tree is a valid BST, otherwise false.</returns>
    public bool IsValidBst()
    {
        // Start the recursive check from the root.
        // We use 'null' to represent infinity, as the root has no bounds.
        return IsValidBstHelper(_root, null, null);
    }

    /// <summary>
    /// Recursive helper function that does the heavy lifting.
    /// </summary>
    /// <param name="node">The current node we are checking.</param>
    /// <param name="min">The minimum value this node can have (lower bound).</param>
    /// <param name="max">The maximum value this node can have (upper bound).</param>
    /// <returns></returns>
    private bool IsValidBstHelper(NodeBst? node, int? min, int? max)
    {
        // 1. Base Case: An empty tree (or the end of a branch) is valid.
        if (node is null)
        {
            return true;
        }

        // 2. Current node check: Does the node's value violate the bounds passed down from its ancestors?
        // If there is a minimum bound and the node's value is less than or equal to it, it's invalid.
        if (min.HasValue && node.Data <= min.Value)
        {
            return false;
        }

        // If there is a maximum bound and the node's value is greater than or equal to it, it's invalid.
        if (max.HasValue && node.Data >= max.Value)
        {
            return false;
        }

        // 3. Recursive Calls: Check the subtrees, updating the bounds.
        // For the left subtree, the current node's value becomes the new MAXIMUM bound.
        // For the right subtree, the current node's value becomes the new MINIMUM bound.
        // Both calls must return 'true' for the tree to be valid.
        return IsValidBstHelper(node.Left, min, node.Data) &&
               IsValidBstHelper(node.Right, node.Data, max);
    }
}