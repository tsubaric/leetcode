#include <iostream>
#include <vector>

class Compression {
public:
    int compress(std::vector<char>& chars) {
        int p = 0, k = 0;
        int n = chars.size();

        auto updateChars = [&]() {
            if (p != 1) {
                int num_len = static_cast<int>(log10(p)) + 1;
                int pw = pow(10, num_len - 1);
                int temp = p;

                while (num_len-- > 0) {
                    int c = temp / pw;
                    chars[k++] = (c + '0');
                    temp -= c * pw;
                    pw /= 10;
                }
            }
        };

        p = 1; // Initialize p to 1
        for (int i = 0; i < n; i++) {
            if (i > 0 && chars[i] == chars[i - 1]) {
                p++;
            } else {
                updateChars();
                chars[k++] = chars[i];
                p = 1;
            }
        }

        updateChars(); // Handle the last group
        return k;
    }
};

int main() {
    Compression compression;

    // Test 1
    std::vector<char> chars1 = {'a', 'a', 'b', 'b', 'c', 'c', 'c'};
    int result1 = compression.compress(chars1);
    std::cout << "Test 1: ";
    for (int i = 0; i < result1; i++) {
        std::cout << chars1[i] << " ";
    }
    std::cout << "\n";

    // Test 2
    std::vector<char> chars2 = {'a'};
    int result2 = compression.compress(chars2);
    std::cout << "Test 2: ";
    for (int i = 0; i < result2; i++) {
        std::cout << chars2[i] << " ";
    }
    std::cout << "\n";

    // Test 3
    std::vector<char> chars3 = {'a', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b', 'b'};
    int result3 = compression.compress(chars3);
    std::cout << "Test 3: ";
    for (int i = 0; i < result3; i++) {
        std::cout << chars3[i] << " ";
    }
    std::cout << "\n";

    return 0;
}
