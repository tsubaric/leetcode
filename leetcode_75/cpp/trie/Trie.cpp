#include <iostream>
#include <vector>

class TrieNode {
public:
    TrieNode *child[26];
    bool isWord;

    TrieNode() {
        isWord = false;
        for (auto &a : child) a = nullptr;
    }
};

class Trie {
    TrieNode* root;

public:
    Trie() {
        root = new TrieNode();
    }

    void insert(std::string s) {
        TrieNode *p = root;
        for (auto &a : s) {
            int i = a - 'a';
            if (!p->child[i]) p->child[i] = new TrieNode();
            p = p->child[i];
        }
        p->isWord = true;
    }

    bool search(std::string key, bool prefix = false) {
        TrieNode *p = root;
        for (auto &a : key) {
            int i = a - 'a';
            if (!p->child[i]) return false;
            p = p->child[i];
        }
        if (prefix == false) return p->isWord;
        return true;
    }

    bool startsWith(std::string prefix) {
        return search(prefix, true);
    }
};

int main() {
    Trie trie;

    // Example
    trie.insert("apple");
    std::cout << "search('apple'): " << (trie.search("apple") ? "true" : "false") << std::endl;
    std::cout << "search('app'): " << (trie.search("app") ? "true" : "false") << std::endl;
    std::cout << "startsWith('app'): " << (trie.startsWith("app") ? "true" : "false") << std::endl;

    // Additional Tests
    trie.insert("app");
    std::cout << "search('app'): " << (trie.search("app") ? "true" : "false") << std::endl;

    return 0;
}
