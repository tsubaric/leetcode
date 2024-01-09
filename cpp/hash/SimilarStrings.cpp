#include <iostream>
#include <unordered_map>
#include <unordered_set>

class SimilarStrings {
public:
    bool closeStrings(std::string word1, std::string word2) {
        if (word1.length() != word2.length()) {
            return false;
        }

        std::unordered_set<char> set1(word1.begin(), word1.end());
        std::unordered_set<char> set2(word2.begin(), word2.end());

        if (set1 != set2) {
            return false;
        }

        std::unordered_map<char, int> freq1, freq2;

        for (char ch : word1) {
            freq1[ch]++;
        }

        for (char ch : word2) {
            freq2[ch]++;
        }

        std::unordered_set<int> counts1, counts2;

        for (const auto& entry : freq1) {
            counts1.insert(entry.second);
        }

        for (const auto& entry : freq2) {
            counts2.insert(entry.second);
        }

        return counts1 == counts2;
    }
};

int main() {
    SimilarStrings similarStrings;

    // Test Case 1
    std::string word1 = "abc";
    std::string word2 = "bca";
    std::cout << "Test Case 1: " << (similarStrings.closeStrings(word1, word2) ? "true" : "false") << std::endl;

    // Test Case 2
    std::string word3 = "a";
    std::string word4 = "aa";
    std::cout << "Test Case 2: " << (similarStrings.closeStrings(word3, word4) ? "true" : "false") << std::endl;

    // Test Case 3
    std::string word5 = "cabbba";
    std::string word6 = "abbccc";
    std::cout << "Test Case 3: " << (similarStrings.closeStrings(word5, word6) ? "true" : "false") << std::endl;

    return 0;
}
