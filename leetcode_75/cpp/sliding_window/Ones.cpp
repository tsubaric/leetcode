#include <iostream>
#include <vector>

class Ones {
public:
    int longestOnes(std::vector<int>& nums, int k) {
        int n = nums.size();
        int left = 0, right = 0;
        int maxOnesCount = 0;
        int zeroCount = 0;

        while (right < n) {
            if (nums[right] == 0) {
                zeroCount++;
            }

            // If the number of zeros in the window exceeds k, shrink the window from the left
            while (zeroCount > k) {
                if (nums[left] == 0) {
                    zeroCount--;
                }
                left++;
            }

            // Update the maximum length of the window
            maxOnesCount = std::max(maxOnesCount, right - left + 1);

            right++;
        }

        return maxOnesCount;
    }
};

int main() {
    Ones ones;

    // Example 1
    std::vector<int> nums1 = {1, 1, 1, 0, 0, 0, 1, 1, 1, 1, 0};
    int k1 = 2;
    int result1 = ones.longestOnes(nums1, k1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::vector<int> nums2 = {0, 0, 1, 1, 0, 0, 1, 1, 1, 0, 1, 1, 0, 0, 0, 1, 1, 1, 1};
    int k2 = 3;
    int result2 = ones.longestOnes(nums2, k2);
    std::cout << "Example 2: " << result2 << std::endl;

    // Additional Test
    std::vector<int> nums3 = {1, 0, 1, 0, 1, 1, 0, 1, 1};
    int k3 = 2;
    int result3 = ones.longestOnes(nums3, k3);
    std::cout << "Additional Test: " << result3 << std::endl;

    return 0;
}
