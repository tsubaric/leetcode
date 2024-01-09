#include <vector>

class Flowers {
public:
    bool canPlaceFlowers(std::vector<int>& flowerbed, int n) {
        int count = 0;
        int size = flowerbed.size();
        int i = 0;

        while (i < size) {
            if (flowerbed[i] == 0) {
                // Check if the next two plots are also empty (or out of bounds)
                bool prevEmpty = (i == 0) || (flowerbed[i - 1] == 0);
                bool nextEmpty = (i == size - 1) || (flowerbed[i + 1] == 0);

                if (prevEmpty && nextEmpty) {
                    // Plant a flower in the middle plot
                    flowerbed[i] = 1;
                    count++;

                    // Skip the next plot as it cannot have a flower due to the rule
                    i += 2;
                }
            }

            // Move to the next plot
            i++;
        }

        // Check if enough flowers can be planted
        return count >= n;
    }
};

int main() {
    Flowers flowers;

    // Example 1
    std::vector<int> flowerbed1 = {1, 0, 0, 0, 1};
    int n1 = 1;
    bool result1 = flowers.canPlaceFlowers(flowerbed1, n1);

    // Example 2
    std::vector<int> flowerbed2 = {1, 0, 0, 0, 1};
    int n2 = 2;
    bool result2 = flowers.canPlaceFlowers(flowerbed2, n2);

    return 0;
}
