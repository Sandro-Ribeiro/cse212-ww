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


    public int Fib(int n)
    {
        if (n <= 2)
        {
            // Fib(2) = 1 and Fib(1) = 1
            return 1;
        }
        else
        {
            // Fib(n) = Fib(n - 1) + Fib(n - 2)
            return Fib(n - 1) + Fib(n - 2);
        }
    }


    public long Fibonacci(int n, Dictionary<int, long>? remember = null)
    {
        // If this is the first time calling the function, then
        // we need to create the dictionary.
        if (remember == null)
            remember = new Dictionary<int, long>();
        // Base Case
        if (n <= 2)
            return 1;
        // Check if we have solved this one before
        if (remember.ContainsKey(n))
            return remember[n];
        // Otherwise solve with recursion
        var result = Fibonacci(n - 1, remember) + Fibonacci(n - 2, remember);
        // Remember result for potential later use
        remember[n] = result;
        return result;
    }

}