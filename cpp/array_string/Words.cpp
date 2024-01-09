#include <string>
#include <sstream>

class Words {
public:
    std::string reverseWords(std::string s) {
        std::istringstream iss(s);
        std::string word;
        std::string result;

        while (iss >> word) {
            reverse(word.begin(), word.end());
            result = word + ' ' + result;
        }

        if (!result.empty()) {
            // Remove the trailing space
            result.pop_back();
        }

        return result;
    }
};

int main() {
    Words words;

    // Example 1
    std::string s1 = "the sky is blue";
    std::string result1 = words.reverseWords(s1);

    // Example 2
    std::string s2 = "  hello world  ";
    std::string result2 = words.reverseWords(s2);

    // Example 3
    std::string s3 = "a good   example";
    std::string result3 = words.reverseWords(s3);

    return 0;
}
