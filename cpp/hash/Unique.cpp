#include <vector>
#include <unordered_map>
#include <unordered_set>
#include <iostream>

class Unique {
public:
    bool uniqueOccurrences(std::vector<int>& arr) {
        std::unordered_map<int, int> occurrenceCount;

        // Count occurrences of each value
        for (int num : arr) {
            occurrenceCount[num]++;
        }

        // Check if the number of occurrences is unique
        std::unordered_set<int> uniqueOccurrences;
        for (const auto& entry : occurrenceCount) {
            if (!uniqueOccurrences.insert(entry.second).second) {
                // If insertion fails, it means the occurrence count is not unique
                return false;
            }
        }

        // If we reach here, all occurrence counts are unique
        return true;
    }
};

int main() {
    Unique unique;

    // Test Case 1
    std::vector<int> arr1 = {1, 2, 2, 1, 1, 3};
    std::cout << "Test Case 1: " << (unique.uniqueOccurrences(arr1) ? "true" : "false") << std::endl;

    // Test Case 2
    std::vector<int> arr2 = {1, 2};
    std::cout << "Test Case 2: " << (unique.uniqueOccurrences(arr2) ? "true" : "false") << std::endl;

    // Test Case 3
    std::vector<int> arr3 = {-3, 0, 1, -3, 1, 1, 1, -3, 10, 0};
    std::cout << "Test Case 3: " << (unique.uniqueOccurrences(arr3) ? "true" : "false") << std::endl;

    return 0;
}
