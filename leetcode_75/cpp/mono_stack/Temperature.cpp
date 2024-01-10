#include <iostream>
#include <vector>

class Temperature {
public:
    std::vector<int> dailyTemperatures(std::vector<int>& temperatures) {
        int n = temperatures.size();
        std::vector<int> ans(n, 0);
        std::stack<int> s;   // store index
        s.push(n-1);

        for(int i = n-2; i >= 0 ; i--) {
            while(!s.empty() && temperatures[s.top()] <= temperatures[i]) s.pop();
            if(s.empty()) {
                s.push(i);
                continue;
            }
            ans[i] = s.top() - i;
            s.push(i);
        }
        return ans;
    }
};

int main() {
    Temperature tempObj;
    
    // Example 1
    std::vector<int> temperatures1 = {73,74,75,71,69,72,76,73};
    std::vector<int> result1 = tempObj.dailyTemperatures(temperatures1);
    std::cout << "Output 1: ";
    for (int i : result1) {
        std::cout << i << " ";
    }
    std::cout << std::endl;

    // Example 2
    std::vector<int> temperatures2 = {30,40,50,60};
    std::vector<int> result2 = tempObj.dailyTemperatures(temperatures2);
    std::cout << "Output 2: ";
    for (int i : result2) {
        std::cout << i << " ";
    }
    std::cout << std::endl;

    // Example 3
    std::vector<int> temperatures3 = {30,60,90};
    std::vector<int> result3 = tempObj.dailyTemperatures(temperatures3);
    std::cout << "Output 3: ";
    for (int i : result3) {
        std::cout << i << " ";
    }
    std::cout << std::endl;

    return 0;
}
