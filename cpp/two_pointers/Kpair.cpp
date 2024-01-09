#include <vector>
#include <unordered_map>

#include <iostream>

class Kpair {
public:
    int maxOperations(std::vector<int>& nums, int k) {
        std::unordered_map<int, int> freq;
        int operations = 0;

        for (int num : nums) {
            int complement = k - num;

            if(freq[complement] > 0) {
                operations++;
                freq[complement]--;
            } else {
                freq[num]++;
            }
        }
        return operations;
    }
};

int main() {
    Kpair kpairs;

    // Example 1
    std::vector<int> nums1 = {1, 2, 3, 4};
    int k1 = 5;
    int result1 = kpairs.maxOperations(nums1, k1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::vector<int> nums2 = {3, 1, 3, 4, 3};
    int k2 = 6;
    int result2 = kpairs.maxOperations(nums2, k2);
    std::cout << "Example 2: " << result2 << std::endl;

    return 0;
}
