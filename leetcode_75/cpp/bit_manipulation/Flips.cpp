#include <iostream>

class Flips {
public:
    int minFlips(int a, int b, int c) {
        int flips = 0;

        for (int i = 0; (1 << i) <= std::max(std::max(a, b), c); i++) {
            int bit = 1 << i;
            int a_bit = a & bit ? 1 : 0;
            int b_bit = b & bit ? 1 : 0;
            int c_bit = c & bit ? 1 : 0;

            if (!(a_bit | b_bit) && c_bit) {
                flips++;
            } else if ((a_bit & b_bit) && !c_bit) {
                flips += 2;
            } else if ((a_bit ^ b_bit) && !c_bit) {
                flips++;
            }
        }

        return flips;
    }
};

int main() {
    // Example 1
    int a1 = 2, b1 = 6, c1 = 5;
    Flips flips1;
    int result1 = flips1.minFlips(a1, b1, c1);

    std::cout << "Example 1:\nOutput: " << result1 << "\n\n";

    // Example 2
    int a2 = 4, b2 = 2, c2 = 7;
    Flips flips2;
    int result2 = flips2.minFlips(a2, b2, c2);

    std::cout << "Example 2:\nOutput: " << result2 << "\n\n";

    // Example 3
    int a3 = 1, b3 = 2, c3 = 3;
    Flips flips3;
    int result3 = flips3.minFlips(a3, b3, c3);

    std::cout << "Example 3:\nOutput: " << result3 << "\n\n";

    return 0;
}
