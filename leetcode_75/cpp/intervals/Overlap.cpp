#include <iostream>
#include <vector>
#include <algorithm>

class Overlap {
public:
    int eraseOverlapIntervals(std::vector<std::vector<int>>& intervals) {
        int count = 0, n = intervals.size();
        std::sort(intervals.begin(), intervals.end());
        int lastStart = intervals[0][0], lastEnd = intervals[0][1];
        for (int i = 1; i < n; i++) {
            if (intervals[i][0] < lastEnd) {
                count++;
                lastEnd = std::min(lastEnd, intervals[i][1]);
            } else {
                lastEnd = intervals[i][1];
                lastStart = intervals[i][0];
            }
        }

        return count;
    }
};

int main() {
    Overlap overlap;

    // Example 1
    std::vector<std::vector<int>> intervals1 = {{1, 2}, {2, 3}, {3, 4}, {1, 3}};
    int result1 = overlap.eraseOverlapIntervals(intervals1);
    std::cout << "Example 1: " << result1 << "\n";

    // Example 2
    std::vector<std::vector<int>> intervals2 = {{1, 2}, {1, 2}, {1, 2}};
    int result2 = overlap.eraseOverlapIntervals(intervals2);
    std::cout << "Example 2: " << result2 << "\n";

    // Example 3
    std::vector<std::vector<int>> intervals3 = {{1, 2}, {2, 3}};
    int result3 = overlap.eraseOverlapIntervals(intervals3);
    std::cout << "Example 3: " << result3 << "\n";

    return 0;
}
