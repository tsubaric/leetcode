using System;

public class Stairs
{
    public int MinCostClimbingStairs(int[] cost)
    {
        int n = cost.Length;
        int[] dp = new int[n + 1];

        for (int i = 2; i <= n; i++)
        {
            dp[i] = Math.Min(dp[i - 1] + cost[i - 1], dp[i - 2] + cost[i - 2]);
        }

        return dp[n];
    }

    public static void Main(string[] args)
    {
        Stairs stairs = new Stairs();

        // Example 1
        int[] cost1 = { 10, 15, 20 };
        int result1 = stairs.MinCostClimbingStairs(cost1);
        Console.WriteLine("Example 1 - Minimum Cost: " + result1);

        // Example 2
        int[] cost2 = { 1, 100, 1, 1, 1, 100, 1, 1, 100, 1 };
        int result2 = stairs.MinCostClimbingStairs(cost2);
        Console.WriteLine("Example 2 - Minimum Cost: " + result2);
    }
}
