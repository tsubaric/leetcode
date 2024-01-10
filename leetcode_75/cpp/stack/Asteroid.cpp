#include <iostream>
#include <vector>
#include <stack>

class Asteroid {
public:
    std::vector<int> asteroidCollision(std::vector<int>& asteroids) {
        std::stack<int> st;

        for (int val : asteroids) {
            if (st.empty() || val > 0) {
                st.push(val);
            } else {
                while (true) {
                    int peek = st.top();
                    if (peek < 0) {
                        st.push(val);
                        break;
                    } else if (peek == -val) {
                        st.pop();
                        break;
                    } else if (peek > -val) {
                        break;
                    } else {
                        st.pop();
                        if (st.empty()) {
                            st.push(val);
                            break;
                        }
                    }
                }
            }
        }

        int size = st.size();
        std::vector<int> ans(size);

        while (!st.empty()) {
            if (size > 0) {
                ans[size - 1] = st.top();
                st.pop();
                size--;
            }
        }

        return ans;
    }
};

int main() {
    Asteroid asteroid;

    // Test Case 1
    std::vector<int> asteroids1 = {5, 10, -5};
    std::vector<int> result1 = asteroid.asteroidCollision(asteroids1);
    std::cout << "Output 1: [";
    for (int val : result1) {
        std::cout << val << " ";
    }
    std::cout << "]" << std::endl;

    // Test Case 2
    std::vector<int> asteroids2 = {8, -8};
    std::vector<int> result2 = asteroid.asteroidCollision(asteroids2);
    std::cout << "Output 2: [";
    for (int val : result2) {
        std::cout << val << " ";
    }
    std::cout << "]" << std::endl;

    // Test Case 3
    std::vector<int> asteroids3 = {10, 2, -5};
    std::vector<int> result3 = asteroid.asteroidCollision(asteroids3);
    std::cout << "Output 3: [";
    for (int val : result3) {
        std::cout << val << " ";
    }
    std::cout << "]" << std::endl;

    return 0;
}
