using System;

public class Transaction
{
    public int MaxProfit(int[] prices, int fee) {
        int n = prices.Length;
        int maxProfit = 0;
        int minPrice = prices[0];
        
        for (int i = 1; i < n; i++) {
            if (prices[i] < minPrice) {
                minPrice = prices[i];
            } 
            else if (prices[i] > minPrice + fee) {
                maxProfit += prices[i] - minPrice - fee;
                minPrice = prices[i] - fee;
            }
        }
        
        return maxProfit;
    }

    public static void Main(string[] args)
    {
        Transaction transaction = new Transaction();

        // Example 1
        int[] prices1 = {1,3,2,8,4,9};
        int fee1 = 2;
        int result1 = transaction.MaxProfit(prices1, fee1);
        Console.WriteLine("Example 1 - Maximum Profit: " + result1);

        // Example 2
        int[] prices2 = {1,3,7,5,10,3};
        int fee2 = 3;
        int result2 = transaction.MaxProfit(prices2, fee2);
        Console.WriteLine("Example 2 - Maximum Profit: " + result2);
    }
}
