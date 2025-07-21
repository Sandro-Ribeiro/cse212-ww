using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("\n=======================\nW03 Interview Question\n=======================\n");

        // Paths to the text files
        string file1 = "../../week03/interview/class01.txt";
        string file2 = "../../week03/interview/class02.txt";

        // Calling Intersection method
        string[] intersection = Intersection(file1, file2);
        int obsIntersection = intersection.Length;

        Console.WriteLine("--- Intersection between files ---\n");

        // Outputs the results to the console
        Console.WriteLine(string.Join("\n", intersection));
        Console.WriteLine($"\nIntersection count {obsIntersection} observations\n");

        Console.WriteLine("\n--- End of the process ---\n");

        string[] union = Union(file1, file2);
        int obsUnion = union.Length;

        Console.WriteLine("\n--- Union between files ---\n");

        // Outputs the results to the console
        Console.WriteLine(string.Join("\n", union));
        Console.WriteLine($"\nUnion count {obsUnion} observations\n");

        Console.WriteLine("\n--- End of the process ---\n");

    }

    public static string[] Intersection(string filename1, string filename2)
    {
        // Read all lines from both file 1 and 2
        string[] file1 = File.ReadAllLines(filename1);
        string[] file2 = File.ReadAllLines(filename2);

        // Inicializing of the HashSets
        HashSet<string> file1Set = new HashSet<string>();
        HashSet<string> interseption = new HashSet<string>();

        // Adding data from file 1 to HashSet
        foreach (string line in file1)
        {
            file1Set.Add(line);
        }

        // Getting the intersection between the data from both file 1 and 2
        foreach (string line in file2)
        {
            if (file1Set.Contains(line))
            {
                interseption.Add(line);
            }
        }

        // Converting the resulting HashSet to an Array and returnning the results
        return interseption.ToArray();
    }

    public static string[] Union(string filename1, string filename2)
    {
        // Read all lines from both files 1 and 2
        string[] file1 = File.ReadAllLines(filename1);
        string[] file2 = File.ReadAllLines(filename2);

        // Inicializing of the HashSets
        HashSet<string> filesUnion = new HashSet<string>();
        
        // Adding data from file 1 to HashSet
        foreach (string line in file1)
        {
            filesUnion.Add(line);
        }

        // Adding data from file 2 to HashSet
        foreach (string line in file2)
        {
            filesUnion.Add(line);
        }

        // Converting the resulting HashSet to an Array and returnning the results
        return filesUnion.ToArray();
    }
}