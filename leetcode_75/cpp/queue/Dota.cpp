#include <iostream>

class Dota {
public:
    std::string predictPartyVictory(std::string senate) {
        std::queue<int> rad, dir;
        int n = senate.length();
        // Add all senators to respect queue with index
        for (int i = 0; i < n; i++){
            if (senate[i] == 'R'){
                rad.push(i);
            }
            else {
                dir.push(i);
            }
        }
        // Use increasing n to keep track of position
        while (!rad.empty() && !dir.empty()){
            // Only "winner" stays in their queue
            if (rad.front() < dir.front()){
                rad.push(n++);
            }
            else {
                dir.push(n++);
            }
            rad.pop(), dir.pop();
        }
        return (rad.empty()) ? ("Dire") : ("Radiant");
    }
};

int main() {
    Dota solution;

    // Test Case 1
    std::string senate1 = "RD";
    std::cout << "Output 1: " << solution.predictPartyVictory(senate1) << std::endl;

    // Test Case 2
    std::string senate2 = "RDD";
    std::cout << "Output 2: " << solution.predictPartyVictory(senate2) << std::endl;

    // Test Case 3
    std::string senate3 = "RRDD";
    std::cout << "Output 3: " << solution.predictPartyVictory(senate3) << std::endl;

    return 0;
}
