public class BinarySearchTree 
{
    private NodeBst? _root;

    // ... outros métodos como Insert, etc. ...

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