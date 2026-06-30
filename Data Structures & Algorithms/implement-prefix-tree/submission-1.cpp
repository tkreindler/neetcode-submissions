class PrefixTree {

    class Node
    {
      public:
        Node()
        {
            this->is_end = false;
            this->children.reserve(26);
        }

        bool is_end;
        unordered_map<char, unique_ptr<Node>> children;
    };

    Node root;

  public:
    PrefixTree()
    {
    }
    
    void insert(string word)
    {
        Node* current = &this->root;

        for (char letter : word)
        {
            unordered_map<char, unique_ptr<Node>>& children = current->children;
            auto iter = children.find(letter);
            if (iter != children.end())
            {
                // exists, use that
                current = iter->second.get();
            }
            else
            {
                // create new
                auto next = std::make_unique<Node>();
                current = next.get();

                children[letter] = std::move(next);
            }
        }

        current->is_end = true; 
    }

    Node* search_helper(string word)
    {
        Node* current = &this->root;

        for (char letter : word)
        {
            unordered_map<char, unique_ptr<Node>>& children = current->children;
            auto iter = children.find(letter);
            if (iter != children.end())
            {
                // exists, use that
                current = iter->second.get();
            }
            else
            {
                // doesn't exist
                return nullptr;
            }
        }

        return current;
    }
    
    bool search(string word)
    {
        Node* found = this->search_helper(word);
        return found != nullptr &&
            found->is_end;
    }
    
    bool startsWith(string prefix)
    {
        Node* found = this->search_helper(prefix);
        return found != nullptr;
    }
};
