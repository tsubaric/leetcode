#include <iostream>

class RecentCounter {
public:
    std::queue<int> q;

    RecentCounter() {
    }

    int ping(int t) {
        int ti = t - 3000;
        q.push(t);
        while (q.front() < ti)
            q.pop();
        return q.size();
    }
};

int main() {
    RecentCounter obj;

    // Test Case 1
    int ping1 = obj.ping(100);
    std::cout << "Ping 1: " << ping1 << std::endl;

    // Test Case 2
    int ping2 = obj.ping(3001);
    std::cout << "Ping 2: " << ping2 << std::endl;

    // Test Case 3
    int ping3 = obj.ping(3002);
    std::cout << "Ping 3: " << ping3 << std::endl;

    // Test Case 4
    int ping4 = obj.ping(6000);
    std::cout << "Ping 4: " << ping4 << std::endl;

    return 0;
}
