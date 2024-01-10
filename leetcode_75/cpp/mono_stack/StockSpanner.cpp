#include <iostream>
#include <vector>

class StockSpanner {
public:
    std::stack<std::pair<int, int>> s;
    int i = 0;

    int next(int price) {
        if (s.empty()) {
            s.push({price, i++});
            return 1;
        } else {
            while (!s.empty() && s.top().first <= price) {
                s.pop();
            }
            int ans;

            if (s.empty())
                ans = i + 1;
            else {
                ans = i - s.top().second;
            }
            s.push({price, i++});
            return ans;
        }
    }
};

int main() {
    StockSpanner* obj = new StockSpanner();

    // Example
    std::vector<int> prices = {100, 80, 60, 70, 60, 75, 85};
    std::cout << "Output: ";
    for (int price : prices) {
        int param = obj->next(price);
        std::cout << param << " ";
    }
    std::cout << std::endl;

    delete obj;
    return 0;
}
