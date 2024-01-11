using System;

public class Common
{
    public int LongestCommonSubsequence(string text1, string text2) {
        int n1 = text1.Length, n2 = text2.Length;
        int[,] dp = new int[n1+1, n2+1];
        for(int j = 1; j <= n2; j++){
            for(int i = 1; i <= n1; i++){
                if(text1[i-1] == text2[j-1]){
                    dp[i,j] = dp[i-1,j-1]+1;
                } else{
                    dp[i,j] = Math.Max(dp[i-1,j], dp[i,j-1]);
                }
            }
        }
        return dp[n1,n2];
    }

    public static void Main(string[] args)
    {
        Common common = new Common();

        // Example 1
        string text1_1 = "abcde", text2_1 = "ace";
        int result1 = common.LongestCommonSubsequence(text1_1, text2_1);
        Console.WriteLine("Example 1 - Length of Longest Common Subsequence: " + result1);

        // Example 2
        string text1_2 = "abc", text2_2 = "abc";
        int result2 = common.LongestCommonSubsequence(text1_2, text2_2);
        Console.WriteLine("Example 2 - Length of Longest Common Subsequence: " + result2);

        // Example 3
        string text1_3 = "abc", text2_3 = "def";
        int result3 = common.LongestCommonSubsequence(text1_3, text2_3);
        Console.WriteLine("Example 3 - Length of Longest Common Subsequence: " + result3);
    }
}
