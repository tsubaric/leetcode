#include <iostream>
#include <vector>
#include <queue>

class Arrows {
    void solve(std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<std::pair<int, int>>>& pq, int e) {
        while (!pq.empty() && pq.top().first <= e) {
            e = std::min(e, pq.top().second);
            pq.pop();
        }
    }

public:
    int findMinArrowShots(std::vector<std::vector<int>>& grid) {
        std::priority_queue<std::pair<int, int>, std::vector<std::pair<int, int>>, std::greater<std::pair<int, int>>> pq;
        for (int i = 0; i < grid.size(); i++) {
            pq.push({grid[i][0], grid[i][1]});
        }
        int cnt = 0;
        while (!pq.empty()) {
            int e = pq.top().second;
            pq.pop();
            solve(pq, e);
            cnt++;
        }
        return cnt;
    }
};

int main() {
    Arrows arrows;

    // Example 1
    std::vector<std::vector<int>> points1 = {{10, 16}, {2, 8}, {1, 6}, {7, 12}};
    int result1 = arrows.findMinArrowShots(points1);
    std::cout << "Example 1: " << result1 << "\n";

    // Example 2
    std::vector<std::vector<int>> points2 = {{1, 2}, {3, 4}, {5, 6}, {7, 8}};
    int result2 = arrows.findMinArrowShots(points2);
    std::cout << "Example 2: " << result2 << "\n";

    // Example 3
    std::vector<std::vector<int>> points3 = {{1, 2}, {2, 3}, {3, 4}, {4, 5}};
    int result3 = arrows.findMinArrowShots(points3);
    std::cout << "Example 3: " << result3 << "\n";

    return 0;
}
