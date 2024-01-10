#include <iostream>
#include <stack>

class DecodeString {
public:
    std::string decodeString(std::string s) {
        std::string ans = "";
        std::stack<char> st;
        std::stack<int> m;
        for (int i = 0; i < s.size(); i++) {
            if (s[i] >= '0' && s[i] <= '9') {
                std::string t = "";
                t.push_back(s[i]);
                for (int j = i + 1; j < s.size(); j++) {
                    if (s[j] >= '0' && s[j] <= '9') {
                        t.push_back(s[j]);
                    } else {
                        i = j - 1;
                        break;
                    }
                }
                int num = std::stoi(t);
                m.push(num);
            } else if (s[i] == ']') {
                int rep = m.top();
                m.pop();
                std::string temp = "";
                while (!st.empty() && st.top() != '[') {
                    temp += st.top();
                    st.pop();
                }
                st.pop();
                std::reverse(temp.begin(), temp.end());
                std::string str = temp;
                for (int j = 1; j < rep; j++) {
                    str += temp;
                }

                if (!st.empty()) {
                    for (int k = 0; k < str.size(); k++) {
                        st.push(str[k]);
                    }
                } else {
                    ans += str;
                }
            } else {
                st.push(s[i]);
            }
        }
        std::string te = "";
        while (!st.empty()) {
            te += st.top();
            st.pop();
        }
        std::reverse(te.begin(), te.end());
        ans += te;
        return ans;
    }
};

int main() {
    DecodeString solution;

    // Test Case 1
    std::string s1 = "3[a]2[bc]";
    std::cout << "Output 1: " << solution.decodeString(s1) << std::endl;

    // Test Case 2
    std::string s2 = "3[a2[c]]";
    std::cout << "Output 2: " << solution.decodeString(s2) << std::endl;

    // Test Case 3
    std::string s3 = "2[abc]3[cd]ef";
    std::cout << "Output 3: " << solution.decodeString(s3) << std::endl;

    return 0;
}
