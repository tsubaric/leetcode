using System;

public class Bananas
{
    public int MinEatingSpeed(int[] piles, int h)
    {
        int left = 1,
            right = piles.Max();
        int result = right;

        while (left <= right)
        {
            int middle = left + (right - left) / 2;

            int hours = 0;
            foreach (int pile in piles)
            {
                hours += (int)Math.Ceiling((double)pile / (double)middle);
            }

            if (hours <= h)
            {
                result = Math.Min(result, middle);
                right = middle - 1;
            }
            else
            {
                left = middle + 1;
            }
        }

        return result;
    }

    public static void Main(string[] args)
    {
        // Example 1
        int[] piles1 = { 3, 6, 7, 11 };
        int h1 = 8;
        Bananas bananas1 = new Bananas();
        int result1 = bananas1.MinEatingSpeed(piles1, h1);
        Console.WriteLine("Example 1 - Minimum Eating Speed: " + result1);

        // Example 2
        int[] piles2 = { 30, 11, 23, 4, 20 };
        int h2 = 5;
        Bananas bananas2 = new Bananas();
        int result2 = bananas2.MinEatingSpeed(piles2, h2);
        Console.WriteLine("Example 2 - Minimum Eating Speed: " + result2);

        // Example 3
        int[] piles3 = { 30, 11, 23, 4, 20 };
        int h3 = 6;
        Bananas bananas3 = new Bananas();
        int result3 = bananas3.MinEatingSpeed(piles3, h3);
        Console.WriteLine("Example 3 - Minimum Eating Speed: " + result3);
    }
}
