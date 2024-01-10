#include <vector>
#include <iostream>

class Zero {
public:
    void moveZeroes(std::vector<int>& nums) {
        int i = 0, j = 0;
        int n = nums.size();

        while(i < n and j < n){
            if(nums[i] != 0) i++;
            if(nums[j] == 0) j++;

            if((i < n and j < n) and (i < j))
                std::swap(nums[i], nums[j]);

            j++;
        }
    }
};

int main() {
    Zero zero;

    // Example 1
    std::vector<int> nums1 = {0, 1, 0, 3, 12};
    zero.moveZeroes(nums1);
    std::cout << "Example 1: [";
    for (int num : nums1) {
        std::cout << num << " ";
    }
    std::cout << "]" << std::endl;

    // Example 2
    std::vector<int> nums2 = {0};
    zero.moveZeroes(nums2);
    std::cout << "Example 2: [";
    for (int num : nums2) {
        std::cout << num << " ";
    }
    std::cout << "]" << std::endl;

    return 0;
}
