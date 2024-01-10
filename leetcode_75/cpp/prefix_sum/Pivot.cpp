#include <vector>
#include <iostream>

class Pivot {
public:
    int pivotIndex(std::vector<int>& nums) {
        int n = nums.size();
        
        // Calculate the total sum of the array
        int totalSum = 0;
        for (int num : nums) {
            totalSum += num;
        }

        // Initialize left sum to 0
        int leftSum = 0;

        // Iterate through the array to find the pivot index
        for (int i = 0; i < n; i++) {
            // Check if the sum of elements on the left is equal to the sum on the right
            if (leftSum == totalSum - leftSum - nums[i]) {
                return i;
            }

            // Update the left sum for the next iteration
            leftSum += nums[i];
        }

        // If no pivot index is found, return -1
        return -1;
    }
};

int main() {
    Pivot pivot;

    // Example 1
    std::vector<int> nums1 = {1, 7, 3, 6, 5, 6};
    int result1 = pivot.pivotIndex(nums1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::vector<int> nums2 = {1, 2, 3};
    int result2 = pivot.pivotIndex(nums2);
    std::cout << "Example 2: " << result2 << std::endl;

    // Example 3
    std::vector<int> nums3 = {2, 1, -1};
    int result3 = pivot.pivotIndex(nums3);
    std::cout << "Example 3: " << result3 << std::endl;

    return 0;
}
