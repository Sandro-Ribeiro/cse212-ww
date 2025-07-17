using System.Diagnostics.Contracts;

public class DuplicateLetters
{
    public static void Run(string word)
    {
        Dictionary<char, int> firstIndex = FirstsDuplicate(word);
        Console.WriteLine(string.Join(", ", firstIndex));
    }

    public static Dictionary<char, int> FirstsDuplicate(string word)
    {
        string newWord = word.ToLower();
        HashSet<char> values = new HashSet<char>();
        Dictionary<char, int> firstIndex = new Dictionary<char, int>();
        for (int i = 0; i < newWord.Length; i++)
        {
            if (!values.Add(newWord[i]))
            {
                if (!firstIndex.ContainsKey(newWord[i]))
                {
                    firstIndex.Add(newWord[i], i);  
                }
            }
        }
        return firstIndex;
    }
}