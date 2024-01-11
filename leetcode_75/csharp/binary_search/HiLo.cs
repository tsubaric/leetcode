using System;

public class GuessGame
{
    protected int PickedNumber { get; set; }

    public GuessGame(int pick)
    {
        PickedNumber = pick;
    }

    public int Guess(int num)
    {
        if (num == PickedNumber) return 0;
        else if (num < PickedNumber) return 1;
        else return -1;
    }
}

public class Solution : GuessGame
{
    public Solution(int pick) : base(pick) { }

    public int GuessNumber(int n)
    {
        int low = 1;
        int high = n;

        // Loop until low and high pointers meet
        while (low <= high)
        {
            // Find the middle point
            int mid = low + (high - low) / 2;

            // Call the pre-defined API to get feedback
            int result = Guess(mid);

            // Check if we have found the answer
            if (result == 0)
            {
                return mid;
            }

            // Check if we need to search in the left half
            else if (result == -1)
            {
                high = mid - 1;
            }

            // Check if we need to search in the right half
            else
            {
                low = mid + 1;
            }
        }

        // Return -1 if no answer is found
        return -1;
    }

    public static void Main(string[] args)
    {
        // Example 1
        int n1 = 10;
        int pick1 = 6;
        Solution solution1 = new Solution(pick1);
        int result1 = solution1.GuessNumber(n1);
        Console.WriteLine("Example 1 - Picked Number: " + result1);

        // Example 2
        int n2 = 1;
        int pick2 = 1;
        Solution solution2 = new Solution(pick2);
        int result2 = solution2.GuessNumber(n2);
        Console.WriteLine("Example 2 - Picked Number: " + result2);

        // Example 3
        int n3 = 2;
        int pick3 = 1;
        Solution solution3 = new Solution(pick3);
        int result3 = solution3.GuessNumber(n3);
        Console.WriteLine("Example 3 - Picked Number: " + result3);
    }
}
