#include <vector>
#include <algorithm>
#include <iostream>

class Subarr {
public:
    double findMaxAverage(std::vector<int>& nums, int k) {
        int n = nums.size();
        double currentSum = 0;

        // Calculate the sum of the first k elements
        for (int i = 0; i < k; i++) {
            currentSum += nums[i];
        }

        // Initialize maxSum to the sum of the first k elements
        double maxSum = currentSum;

        // Slide the window to calculate the sum of subsequent k elements
        for (int i = k; i < n; i++) {
            currentSum += nums[i] - nums[i - k];
            maxSum = std::max(maxSum, currentSum);
        }

        // Calculate the average and return
        return maxSum / k;
    }
};

int main() {
    Subarr subarr;

    // Example 1
    std::vector<int> nums1 = {1, 12, -5, -6, 50, 3};
    int k1 = 4;
    double result1 = subarr.findMaxAverage(nums1, k1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::vector<int> nums2 = {5};
    int k2 = 1;
    double result2 = subarr.findMaxAverage(nums2, k2);
    std::cout << "Example 2: " << result2 << std::endl;

    return 0;
}