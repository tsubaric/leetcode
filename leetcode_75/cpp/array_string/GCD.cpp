#include <string>

class GCD {
public:
    std::string gcdOfStrings(std::string str1, std::string str2) {
        // Check if concatenated strings are equal or not, if not return ""
        if (str1 + str2 != str2 + str1)
            return "";
        // If strings are equal than return the substring from 0 to gcd of size(str1), size(str2)
        return str1.substr(0, findGCD(str1.size(), str2.size()));
    }

private:
    // Helper function to find the greatest common divisor (gcd)
    int findGCD(int a, int b) {
        while (b != 0) {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
};

int main() {
    GCD gcdCalculator;
    std::string str1 = "ABCABC";
    std::string str2 = "ABC";
    std::string result = gcdCalculator.gcdOfStrings(str1, str2);

    return 0;
}
