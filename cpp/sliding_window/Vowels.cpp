#include <string>
#include <algorithm>
#include <iostream>

class Vowels {
public:
    int maxVowels(std::string s, int k) {
        int n = s.length();
        int maxVowelCount = 0;
        int currentVowelCount = 0;

        // Calculate the vowel count for the first window of size k
        for (int i = 0; i < k; i++) {
            if (isVowel(s[i])) {
                currentVowelCount++;
            }
        }

        maxVowelCount = currentVowelCount;

        // Slide the window to calculate the vowel count for subsequent windows
        for (int i = k; i < n; i++) {
            if (isVowel(s[i - k])) {
                currentVowelCount--;
            }
            if (isVowel(s[i])) {
                currentVowelCount++;
            }
            maxVowelCount = std::max(maxVowelCount, currentVowelCount);
        }

        return maxVowelCount;
    }

private:
    bool isVowel(char c) {
        return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
    }
};

int main() {
    Vowels vowels;

    // Example 1
    std::string s1 = "abciiidef";
    int k1 = 3;
    int result1 = vowels.maxVowels(s1, k1);
    std::cout << "Example 1: " << result1 << std::endl;

    // Example 2
    std::string s2 = "aeiou";
    int k2 = 2;
    int result2 = vowels.maxVowels(s2, k2);
    std::cout << "Example 2: " << result2 << std::endl;

    // Example 3
    std::string s3 = "leetcode";
    int k3 = 3;
    int result3 = vowels.maxVowels(s3, k3);
    std::cout << "Example 3: " << result3 << std::endl;

    // Additional Test
    std::string s4 = "abracadabra";
    int k4 = 5;
    int result4 = vowels.maxVowels(s4, k4);
    std::cout << "Additional Test: " << result4 << std::endl;

    return 0;
}
