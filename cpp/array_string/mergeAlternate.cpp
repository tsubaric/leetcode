#include <string>

class MergeAlternate {
public:
    std::string mergeAlternately(std::string word1, std::string word2) {
        int i = 0, j = 0;
        std::string result = "";

        while (i < word1.length() && j < word2.length()) {
            result += word1[i++];
            result += word2[j++];
        }

        while (i < word1.length()) {
            result.push_back(word1[i++]);
        }

        while (j < word2.length()) {
            result.push_back(word2[j++]);
        }

        return result;
    }
};

int main() {
    MergeAlternate merger;
    std::string word1 = "abc";
    std::string word2 = "defgh";
    std::string merged = merger.mergeAlternately(word1, word2);

    return 0;
}
