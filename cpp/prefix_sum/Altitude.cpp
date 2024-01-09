#include <vector>
#include <iostream>

class Altitude {
public:
    int largestAltitude(std::vector<int>& gain) {
        int currentAltitude = 0;
        int maxAltitude = 0;

        for (int i : gain) {
            currentAltitude += i;
            maxAltitude = std::max(maxAltitude, currentAltitude);
        }

        return maxAltitude;
    }
};

int main() {
    Altitude altitude;

    // Example 1
    std::vector<int> gain1 = {-5, 1, 5, 0, -7};
    int result1 = altitude.largestAltitude(gain1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::vector<int> gain2 = {-4, -3, -2, -1, 4, 3, 2};
    int result2 = altitude.largestAltitude(gain2);
    std::cout << "Example 2: " << result2 << std::endl;

    return 0;
}