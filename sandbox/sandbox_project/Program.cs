using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n=======================");
        Console.WriteLine("Executando teste de Interseção a partir do Sandbox");

        // Caminhos para seus arquivos de teste
        string file1 = "../../week03/interview/class01.txt";
        string file2 = "../../week03/interview/class02.txt";

        // Chamada ao seu método da classe Interview
        string[] result = Intersection(file1, file2);

        Console.WriteLine("\n--- Interseção Encontrada ---");
        // Imprime cada item da interseção em uma nova linha
        Console.WriteLine(string.Join("\n", result));
        Console.WriteLine("--- Fim do Teste ---");
    }

    public static string[] Intersection(string filename1, string filename2)
    {
        string[] class01Readed = File.ReadAllLines(filename1);
        string[] class02Readed = File.ReadAllLines(filename2);
        HashSet<string> class01 = new HashSet<string>();
        HashSet<string> interseption = new HashSet<string>();

        foreach (string line in class01Readed)
        {
            class01.Add(line);
        }

        foreach (string line in class02Readed)
        {
            if (class01.Contains(line))
            {
                interseption.Add(line);
            }
        }
        var interseptionArray = interseption.ToArray();
        return interseptionArray;
    }

}