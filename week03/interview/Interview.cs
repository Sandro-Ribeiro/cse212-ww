using System.IO;

public static class Interview
{
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