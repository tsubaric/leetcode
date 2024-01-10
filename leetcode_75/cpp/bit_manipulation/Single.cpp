#include <iostream>
#include <vector>
#include <algorithm>

class Single {
public:
    int singleNumber(std::vector<int>& nums) { 
        std::sort(nums.begin(), nums.end());
        for (int i = 1; i < nums.size(); i += 2) {
            if (nums[i] != nums[i - 1])
                return nums[i - 1];
        }
        return nums[nums.size() - 1];
    }
};

int main() {
    // Example 1
    std::vector<int> nums1 = {2, 2, 1};
    Single single1;
    int result1 = single1.singleNumber(nums1);

    std::cout << "Example 1:\nOutput: " << result1 << "\n\n";

    // Example 2
    std::vector<int> nums2 = {4, 1, 2, 1, 2};
    Single single2;
    int result2 = single2.singleNumber(nums2);

    std::cout << "Example 2:\nOutput: " << result2 << "\n\n";

    // Example 3
    std::vector<int> nums3 = {1};
    Single single3;
    int result3 = single3.singleNumber(nums3);

    std::cout << "Example 3:\nOutput: " << result3 << "\n\n";

    return 0;
}
