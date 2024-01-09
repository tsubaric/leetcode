#include <vector>
#include <unordered_set>
#include <iostream>

class TwoArray {
public:
    std::vector<std::vector<int>> findDifference(std::vector<int>& nums1, std::vector<int>& nums2) {
        std::vector<std::vector<int>> answer(2);
        
        // Create sets for nums1 and nums2
        std::unordered_set<int> set1(nums1.begin(), nums1.end());
        std::unordered_set<int> set2(nums2.begin(), nums2.end());

        // Find distinct integers in nums1 that are not in nums2
        std::unordered_set<int> seen;
        for (int num : nums1) {
            if (set2.find(num) == set2.end() && seen.find(num) == seen.end()) {
                answer[0].push_back(num);
                seen.insert(num);
            }
        }

        // Find distinct integers in nums2 that are not in nums1
        seen.clear();
        for (int num : nums2) {
            if (set1.find(num) == set1.end() && seen.find(num) == seen.end()) {
                answer[1].push_back(num);
                seen.insert(num);
            }
        }

        return answer;
    }
};

int main() {
    TwoArray twoArray;

    // Example 1
    std::vector<int> nums1 = {1, 2, 3};
    std::vector<int> nums2 = {2, 4, 6};
    std::vector<std::vector<int>> result1 = twoArray.findDifference(nums1, nums2);
    std::cout << "Example 1: [" << result1[0][0] << "," << result1[0][1] << "]"
              << ", [" << result1[1][0] << "," << result1[1][1] << "]" << std::endl;

    // Example 2
    std::vector<int> nums3 = {1, 2, 3, 3};
    std::vector<int> nums4 = {1, 1, 2, 2};
    std::vector<std::vector<int>> result2 = twoArray.findDifference(nums3, nums4);
    std::cout << "Example 2: [" << result2[0][0] << "]" << ", [" << result2[1][0] << "]" << std::endl;

    return 0;
}
