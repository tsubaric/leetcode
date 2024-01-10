#include <vector>
#include <algorithm>
#include <iostream>

class Water {
public:
    int maxArea(std::vector<int>& height) {
        int left = 0;
        int right = height.size() - 1;
        int maxArea = 0;

        while (left < right) {
            int currentArea = std::min(height[left], height[right]) * (right - left);
            maxArea = std::max(maxArea, currentArea);

            if (height[left] < height[right]) {
                left++;
            } else {
                right--;
            }
        }
        return maxArea;
    }
};

int main() {
    Water water;

    // Example 1
    std::vector<int> height1 = {1, 8, 6, 2, 5, 4, 8, 3, 7};
    int result1 = water.maxArea(height1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::vector<int> height2 = {1, 1};
    int result2 = water.maxArea(height2);
    std::cout << "Example 2: " << result2 << std::endl;

    return 0;
}
