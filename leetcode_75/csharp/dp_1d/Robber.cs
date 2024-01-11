using System;

public class Robber
{
    public int Rob(int[] nums)
    {
        // If we only have two elements, we cannot skip any house, so return the max of the two.
        if (nums.Length < 3) return nums.Max();

        // Create an array to store the maximum looted value based on each index.
        int[] maximumRobbed = new int[nums.Length];
        maximumRobbed[0] = nums[0];
        maximumRobbed[1] = Math.Max(nums[0], nums[1]);

        for (int i = 2; i < nums.Length; i++)
        {
            // If we choose to loot
            int ifLooted = maximumRobbed[i - 2] + nums[i];
            // If not choose to loot
            int ifNotLooted = maximumRobbed[i - 1];
            // Taking the maximum and store it in the maximumRobbed array.
            maximumRobbed[i] = Math.Max(ifLooted, ifNotLooted);
        }

        return maximumRobbed[nums.Length - 1];
    }

    public static void Main(string[] args)
    {
        Robber robber = new Robber();

        // Example 1
        int[] nums1 = { 1, 2, 3, 1 };
        int result1 = robber.Rob(nums1);
        Console.WriteLine("Example 1 - Maximum Loot: " + result1);

        // Example 2
        int[] nums2 = { 2, 7, 9, 3, 1 };
        int result2 = robber.Rob(nums2);
        Console.WriteLine("Example 2 - Maximum Loot: " + result2);
    }
}
