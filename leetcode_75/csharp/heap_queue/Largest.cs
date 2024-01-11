using System;

public class Largest {
    public int FindKthLargest(int[] nums, int k) {
        // Ensure k is within valid range
        if (k < 1 || k > nums.Length) {
            throw new ArgumentException("Invalid value for k");
        }

        // Use the QuickSelect algorithm to find the kth largest element
        int left = 0, right = nums.Length - 1;
        while (left <= right) {
            int pivotIndex = Partition(nums, left, right);

            if (pivotIndex == nums.Length - k) {
                return nums[pivotIndex];
            } else if (pivotIndex < nums.Length - k) {
                left = pivotIndex + 1;
            } else {
                right = pivotIndex - 1;
            }
        }

        throw new InvalidOperationException("Should not reach here");
    }

    private int Partition(int[] nums, int left, int right) {
        int pivot = nums[right];
        int i = left - 1;

        for (int j = left; j < right; j++) {
            if (nums[j] <= pivot) {
                i++;
                Swap(nums, i, j);
            }
        }

        Swap(nums, i + 1, right);
        return i + 1;
    }

    private void Swap(int[] nums, int i, int j) {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    public static void Main(string[] args) {
        // Example 1
        int[] nums1 = {3, 2, 1, 5, 6, 4};
        int k1 = 2;
        Largest largest1 = new Largest();
        int result1 = largest1.FindKthLargest(nums1, k1);
        Console.WriteLine("Example 1 - Kth largest element: " + result1);

        // Example 2
        int[] nums2 = {3, 2, 3, 1, 2, 4, 5, 5, 6};
        int k2 = 4;
        Largest largest2 = new Largest();
        int result2 = largest2.FindKthLargest(nums2, k2);
        Console.WriteLine("Example 2 - Kth largest element: " + result2);
    }
}

// public class Solution {
//     public int FindKthLargest(int[] nums, int k) {
//         Array.Sort(nums);
//         return nums[nums.Length - k];
//     }
// }
