#include <vector>

class Array {
public:
    std::vector<int> productExceptSelf(std::vector<int>& nums) {
        int n = nums.size();
        std::vector<int> output(n, 1);

        // Calculate product of elements to the left
        int left = 1;
        for (int i = 1; i < n; i++) {
            left *= nums[i - 1];
            output[i] *= left;
        }

        // Calculate product of elements to the right and multiply with the left product
        int right = 1;
        for (int i = n - 1; i >= 0; i--) {
            output[i] *= right;
            right *= nums[i];
        }

        return output;
    }
};

int main() {
    Array array;

    // Example 1
    std::vector<int> nums1 = {1, 2, 3, 4};
    std::vector<int> result1 = array.productExceptSelf(nums1);

    // Example 2
    std::vector<int> nums2 = {-1, 1, 0, -3, 3};
    std::vector<int> result2 = array.productExceptSelf(nums2);

    return 0;
}
