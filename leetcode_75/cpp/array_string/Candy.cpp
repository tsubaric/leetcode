#include <vector>

class Candy {
public:
    std::vector<bool> kidsWithCandies(std::vector<int>& candies, int extraCandies) {
        int maxCandies = 0;
        // Find the maximum number of candies among all kids
        for (int candy : candies) {
            maxCandies = std::max(maxCandies, candy);
        }

        // Initialize the result vector with false
        std::vector<bool> result(candies.size(), false);

        // Check if each kid can have the greatest number of candies
        for (int i = 0; i < candies.size(); ++i) {
            if (candies[i] + extraCandies >= maxCandies) {
                result[i] = true;
            }
        }

        return result;
    }
};

int main() {
    Candy candy;

    // Example 1
    std::vector<int> candies1 = {2, 3, 5, 1, 3};
    int extraCandies1 = 3;
    std::vector<bool> result1 = candy.kidsWithCandies(candies1, extraCandies1);

    // Example 2
    std::vector<int> candies2 = {4, 2, 1, 1, 2};
    int extraCandies2 = 1;
    std::vector<bool> result2 = candy.kidsWithCandies(candies2, extraCandies2);

    // Example 3
    std::vector<int> candies3 = {12, 1, 12};
    int extraCandies3 = 10;
    std::vector<bool> result3 = candy.kidsWithCandies(candies3, extraCandies3);

    return 0;
}
