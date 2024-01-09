#include <iostream>
#include <vector>

class Longest_Subarr {
public:
    int longestSubarray(std::vector<int>& nums) {
        int n = nums.size();
        int left = 0, right = 0;
        int maxOnesCount = 0;
        int zeroCount = 0;

        while (right < n) {
            if (nums[right] == 0) {
                zeroCount++;
            }

            // If more than one zero is present, shrink the window from the left
            while (zeroCount > 1) {
                if (nums[left] == 0) {
                    zeroCount--;
                }
                left++;
            }

            // Update the maximum length of the window
            maxOnesCount = std::max(maxOnesCount, right - left);

            right++;
        }

        return maxOnesCount;
    }
};

int main() {
    Longest_Subarr solution;

    // Example 1
    std::vector<int> nums1 = {1, 1, 0, 1};
    int result1 = solution.longestSubarray(nums1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::vector<int> nums2 = {0, 1, 1, 1, 0, 1, 1, 0, 1};
    int result2 = solution.longestSubarray(nums2);
    std::cout << "Example 2: " << result2 << std::endl;

    // Example 3
    std::vector<int> nums3 = {1, 1, 1};
    int result3 = solution.longestSubarray(nums3);
    std::cout << "Example 3: " << result3 << std::endl;

    return 0;
}
