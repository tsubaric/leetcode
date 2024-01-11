using System;

public class Unique
{
    public int UniquePaths(int m, int n) {
        int[,] dp = new int[m, n];
        
        for (int i = 0; i < m; i++) {
            dp[i, 0] = 1;
        }
        for (int j = 0; j < n; j++) {
            dp[0, j] = 1;
        }
        
        for (int i = 1; i < m; i++) {
            for (int j = 1; j < n; j++) {
                dp[i, j] = dp[i-1, j] + dp[i, j-1];
            }
        }
        
        return dp[m-1, n-1];
    }

    public static void Main(string[] args)
    {
        Unique unique = new Unique();

        // Example 1
        int m1 = 3, n1 = 7;
        int result1 = unique.UniquePaths(m1, n1);
        Console.WriteLine("Example 1 - Number of Unique Paths: " + result1);

        // Example 2
        int m2 = 3, n2 = 2;
        int result2 = unique.UniquePaths(m2, n2);
        Console.WriteLine("Example 2 - Number of Unique Paths: " + result2);
    }
}
