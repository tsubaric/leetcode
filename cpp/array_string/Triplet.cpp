#include <vector>
#include <climits>

class Triplet {
public:
    bool increasingTriplet(std::vector<int>& nums) {
        int n = nums.size();
        int i = INT_MAX, j = INT_MAX, k = INT_MIN;

        for (int index = 0; index < n; index++) {
            i = std::min(i, nums[index]);

            if (i < nums[index]) {
                j = std::min(j, nums[index]);
            }

            if (j < nums[index]) {
                k = std::max(k, nums[index]);
            }

            if (i < j && j < k) {
                return true;
            }
        }

        return false;
    }
};

int main() {
    Triplet triplet;

    // Example 1
    std::vector<int> nums1 = {1, 2, 3, 4, 5};
    bool result1 = triplet.increasingTriplet(nums1);

    // Example 2
    std::vector<int> nums2 = {5, 4, 3, 2, 1};
    bool result2 = triplet.increasingTriplet(nums2);

    // Example 3
    std::vector<int> nums3 = {2, 1, 5, 0, 4, 6};
    bool result3 = triplet.increasingTriplet(nums3);

    return 0;
}
