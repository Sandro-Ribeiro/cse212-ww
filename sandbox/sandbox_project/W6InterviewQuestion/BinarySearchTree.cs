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
    /// Função pública que o usuário chama para iniciar a validação.
    /// </summary>
    /// <returns>True se a árvore for uma BST válida, caso contrário, false.</returns>
    public bool IsValidBst()
    {
        // Inicia a verificação recursiva a partir da raiz.
        // Usamos 'null' para representar infinito, já que a raiz não tem limites.
        return IsValidBstHelper(_root, null, null);
    }

    /// <summary>
    /// Função auxiliar recursiva que faz o trabalho pesado.
    /// </summary>
    /// <param name="node">O nó atual que estamos verificando.</param>
    /// <param name="min">O valor mínimo que este nó pode ter (limite inferior).</param>
    /// <param name="max">O valor máximo que este nó pode ter (limite superior).</param>
    /// <returns></returns>
    private bool IsValidBstHelper(NodeBst? node, int? min, int? max)
    {
        // 1. Caso Base: Uma árvore vazia (ou o fim de um galho) é válida.
        if (node is null)
        {
            return true;
        }

        // 2. Verificação do nó atual: O valor do nó viola os limites passados por seus ancestrais?
        // Se houver um limite mínimo e o valor do nó for menor ou igual a ele, é inválido.
        if (min.HasValue && node.Data <= min.Value)
        {
            return false;
        }

        // Se houver um limite máximo e o valor do nó for maior ou igual a ele, é inválido.
        if (max.HasValue && node.Data >= max.Value)
        {
            return false;
        }

        // 3. Chamadas Recursivas: Verifique as subárvores, atualizando os limites.
        // Para a subárvore esquerda, o valor do nó atual se torna o novo limite MÁXIMO.
        // Para a subárvore direita, o valor do nó atual se torna o novo limite MÍNIMO.
        // Ambas as chamadas devem retornar 'true' para a árvore ser válida.
        return IsValidBstHelper(node.Left, min, node.Data) &&
               IsValidBstHelper(node.Right, node.Data, max);
    }
}