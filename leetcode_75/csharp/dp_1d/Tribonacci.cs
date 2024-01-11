using System;

public class Tribonacci
{
    public int TribonacciNumber(int n)
    {
        var arr = new int[3] { 0, 1, 1 };

        for (int i = 3; i <= n; i++)
        {
            arr[i % 3] = arr[0] + arr[1] + arr[2];
        }

        return arr[n % 3];
    }

    public static void Main(string[] args)
    {
        Tribonacci tribonacci = new Tribonacci();

        // Example 1
        int n1 = 4;
        int result1 = tribonacci.TribonacciNumber(n1);
        Console.WriteLine("Example 1 - Tribonacci Number: " + result1);

        // Example 2
        int n2 = 25;
        int result2 = tribonacci.TribonacciNumber(n2);
        Console.WriteLine("Example 2 - Tribonacci Number: " + result2);
    }
}
