using System;

public class Peak
{
    public int FindPeakElement(int[] nums)
    {
        var left = 0;
        var right = nums.Length - 1;

        while (left + 1 < right)
        {
            var mid = left + (right - left) / 2;

            if (nums[mid] < nums[mid + 1])
            {
                left = mid;
            }
            else
            {
                right = mid;
            }
        }

        return nums[left] > nums[right] ? left : right;
    }

    public static void Main(string[] args)
    {
        // Example 1
        int[] nums1 = { 1, 2, 3, 1 };
        Peak peak1 = new Peak();
        int result1 = peak1.FindPeakElement(nums1);
        Console.WriteLine("Example 1 - Peak Element Index: " + result1);

        // Example 2
        int[] nums2 = { 1, 2, 1, 3, 5, 6, 4 };
        Peak peak2 = new Peak();
        int result2 = peak2.FindPeakElement(nums2);
        Console.WriteLine("Example 2 - Peak Element Index: " + result2);
    }
}
