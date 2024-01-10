#include <string>

class Vowels {
public:
    std::string reverseVowels(std::string s) {
        int l = 0;
        int r = s.size() - 1;
        
        while (l < r) {
            if (!isVowel(s[l])) {
                l++;
            }
            if (!isVowel(s[r])) {
                r--;
            }
            if (isVowel(s[l]) && isVowel(s[r])) {
                std::swap(s[l++], s[r--]);
            }
        }
        
        return s;
    }

    bool isVowel(char x) {
        return x == 'a' || x == 'e' || x == 'i' || x == 'o' || x == 'u' ||
               x == 'A' || x == 'E' || x == 'I' || x == 'O' || x == 'U';
    }
};

int main() {
    Vowels vowels;

    // Example 1
    std::string s1 = "hello";
    std::string result1 = vowels.reverseVowels(s1);

    // Example 2
    std::string s2 = "leetcode";
    std::string result2 = vowels.reverseVowels(s2);

    return 0;
}
