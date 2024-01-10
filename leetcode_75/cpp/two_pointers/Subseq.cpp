#include <string>
#include <iostream>

class Subseq {
public:
    bool isSubsequence(std::string s, std::string t) {
        int i = 0, j = 0;
        while (j < t.length() && i < s.length()) {
            if (s[i] == t[j])
                i++;
            j++;
        }
        return i == s.length();
    }
};

int main() {
    Subseq subseq;

    // Example 1
    std::string s1 = "abc";
    std::string t1 = "ahbgdc";
    bool result1 = subseq.isSubsequence(s1, t1);
    std::cout << "Example 1: " << std::boolalpha << result1 << std::endl;

    // Example 2
    std::string s2 = "axc";
    std::string t2 = "ahbgdc";
    bool result2 = subseq.isSubsequence(s2, t2);
    std::cout << "Example 2: " << std::boolalpha << result2 << std::endl;

    return 0;
}
