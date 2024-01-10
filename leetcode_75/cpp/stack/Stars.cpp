#include <iostream>
#include <string>

class Stars {
public:
    std::string removeStars(std::string s) {
        std::string c = "";
        for (int i = 0; i < s.size(); i++) {
            if (s[i] == '*') {
                c.pop_back();
            } else {
                c += s[i];
            }
        }
        return c;
    }
};

int main() {
    Stars stars;

    // Test Case 1
    std::string s1 = "leet**cod*e";
    std::cout << "Output 1: " << stars.removeStars(s1) << std::endl;

    // Test Case 2
    std::string s2 = "erase*****";
    std::cout << "Output 2: " << stars.removeStars(s2) << std::endl;

    return 0;
}
