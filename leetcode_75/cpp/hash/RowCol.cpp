#include <iostream>
#include <vector>
#include <unordered_map>

class RowCol {
public:
    int equalPairs(std::vector<std::vector<int>>& grid) {
        std::unordered_map<std::string, int> row;
        std::string temp;
        
        // Count equal rows
        for (int i = 0; i < grid.size(); i++) {
            temp = "";
            for (int j = 0; j < grid[0].size(); j++) {
                temp += std::to_string(grid[i][j]);
                temp += " ";
            }
            row[temp] += 1;
        }

        int ans = 0;
        
        // Count equal columns
        for (int i = 0; i < grid.size(); ++i) {
            temp = "";
            for (int j = 0; j < grid[0].size(); j++) {
                temp += std::to_string(grid[j][i]);
                temp += " ";
            }
            if (row[temp]) {
                ans += row[temp];
            }
        }

        return ans;
    }
};

int main() {
    RowCol rowCol;

    // Test Case
    std::vector<std::vector<int>> grid = {{3, 2, 1}, {1, 7, 6}, {2, 7, 7}};
    std::cout << "Output: " << rowCol.equalPairs(grid) << std::endl;

    return 0;
}
