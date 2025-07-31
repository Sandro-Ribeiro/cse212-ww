public class Recursion
{
    public int sumSequence(int number)
    {
        if (number == 1)
        {
            return 1;
        }
        return number + sumSequence(number - 1);
    }
}