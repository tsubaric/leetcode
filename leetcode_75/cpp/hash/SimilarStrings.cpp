#include <iostream>

class SimilarStrings {
public:
    bool closeStrings(std::string word1, std::string word2) {
        std::unordered_map<char, int> m1;
        std::unordered_map<char, int> m2;
        std::vector<int> v1;
        std::vector<int> v2;

        for (auto x : word1) {
            m1[x]++;
        }

        for (auto x : word2) {
            m2[x]++;
        }

        for (auto x : m1) {
            if (m2[x.first] == 0) {
                return false;
            }
            v1.push_back(m1[x.first]);
            v2.push_back(m2[x.first]);
        }

        std::sort(v1.begin(), v1.end());
        std::sort(v2.begin(), v2.end());

        return v1 == v2;
    }
};

int main() {
    SimilarStrings solution;

    // Test Case 1
    std::string word1_1 = "abc";
    std::string word2_1 = "bca";
    std::cout << "Output 1: " << std::boolalpha << solution.closeStrings(word1_1, word2_1) << std::endl;

    // Test Case 2
    std::string word1_2 = "a";
    std::string word2_2 = "aa";
    std::cout << "Output 2: " << std::boolalpha << solution.closeStrings(word1_2, word2_2) << std::endl;

    // Test Case 3
    std::string word1_3 = "cabbba";
    std::string word2_3 = "abbccc";
    std::cout << "Output 3: " << std::boolalpha << solution.closeStrings(word1_3, word2_3) << std::endl;

    return 0;
}
