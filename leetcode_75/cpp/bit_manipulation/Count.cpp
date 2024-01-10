#include <iostream>
#include <vector>

class Count {
public:
    std::vector<int> countBits(int n) {
        std::vector<int> counter(n + 1);
        for (int i = 1; i <= n; i++) {
            counter[i] = counter[i / 2] + i % 2;
        }
        return counter;
    }
};

int main() {
    // Example 1
    int n1 = 2;
    Count count1;
    std::vector<int> result1 = count1.countBits(n1);

    std::cout << "Example 1:\nOutput: [";
    for (int i = 0; i <= n1; i++) {
        std::cout << result1[i];
        if (i < n1) std::cout << ",";
    }
    std::cout << "]\n\n";

    // Example 2
    int n2 = 5;
    Count count2;
    std::vector<int> result2 = count2.countBits(n2);

    std::cout << "Example 2:\nOutput: [";
    for (int i = 0; i <= n2; i++) {
        std::cout << result2[i];
        if (i < n2) std::cout << ",";
    }
    std::cout << "]\n\n";

    return 0;
}
