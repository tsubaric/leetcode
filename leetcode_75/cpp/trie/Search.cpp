#include <iostream>
#include <vector>
#include <stack>
#include <algorithm>

struct Node {
    Node* links[26];
    bool flag = false;
    std::vector<std::string> words;

    bool containsKey(char ch) {
        return links[ch - 'a'] != NULL;
    }

    void put(char ch, Node* node) {
        links[ch - 'a'] = node;
    }

    Node* get(char ch) {
        return links[ch - 'a'];
    }

    void setEnd() {
        flag = true;
    }
};

class Search {
public:
    void insert(Node* trie, std::string word, std::stack<Node*>& st) {
        st.push(trie);
        for (int i = 0; i < word.length(); i++) {
            if (!trie->containsKey(word[i])) {
                trie->put(word[i], new Node());
            }
            trie = trie->get(word[i]);
            st.push(trie);
        }
        trie->setEnd();
    }

    std::vector<std::vector<std::string>> suggestedProducts(std::vector<std::string>& products, std::string searchWord) {
        std::vector<std::vector<std::string>> ans(searchWord.length());
        std::sort(products.begin(), products.end());
        Node* trie = new Node();
        for (auto word : products) {
            std::stack<Node*> st;
            insert(trie, word, st);
            while (!st.empty()) {
                Node* temp = st.top();
                st.pop();
                if (temp->words.size() < 3) temp->words.push_back(word);
            }
        }
        for (int i = 0; i < searchWord.length(); i++) {
            if (!trie->containsKey(searchWord[i])) {
                return ans;
            }
            trie = trie->get(searchWord[i]);
            ans[i] = trie->words;
        }
        return ans;
    }
};

int main() {
    Search search;

    // Example 1
    std::vector<std::string> products1 = {"mobile", "mouse", "moneypot", "monitor", "mousepad"};
    std::string searchWord1 = "mouse";
    std::vector<std::vector<std::string>> result1 = search.suggestedProducts(products1, searchWord1);

    std::cout << "Example 1:\n";
    for (const auto& res : result1) {
        std::cout << "[";
        for (const auto& word : res) {
            std::cout << "\"" << word << "\",";
        }
        std::cout << "]\n";
    }

    // Example 2
    std::vector<std::string> products2 = {"havana"};
    std::string searchWord2 = "havana";
    std::vector<std::vector<std::string>> result2 = search.suggestedProducts(products2, searchWord2);

    std::cout << "\nExample 2:\n";
    for (const auto& res : result2) {
        std::cout << "[";
        for (const auto& word : res) {
            std::cout << "\"" << word << "\",";
        }
        std::cout << "]\n";
    }

    return 0;
}
