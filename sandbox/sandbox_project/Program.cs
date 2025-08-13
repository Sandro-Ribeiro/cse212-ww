using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        // SetOperations.Run();

        // Exemplo para o Program.cs do Sandbox
        var bst = new BinarySearchTree();
        bst.Insert(10);
        bst.Insert(5);
        bst.Insert(15);

        Console.WriteLine($"Is this tree a valid BST? {bst.IsValidBst()}"); // Deve imprimir True

        
    }
}