class BrowserHistory {

    vector<string> back_history;
    vector<string> forward_history;
    string current;


  public:
    BrowserHistory(string homepage)
    {
        this->current = homepage;
    }
    
    void visit(string url)
    {
        this->forward_history.clear();

        this->back_history.push_back(std::move(current));

        this->current = std::move(url);
    }
    
    string back(int steps)
    {
        for (int i = 0; i < steps; ++i)
        {
            if (back_history.size() == 0)
            {
                break;
            }

            forward_history.push_back(std::move(this->current));
            this->current = std::move(this->back_history.back());
            this->back_history.pop_back();
        }

        return this->current;
    }
    
    string forward(int steps)
    {
        for (int i = 0; i < steps; ++i)
        {
            if (forward_history.size() == 0)
            {
                break;
            }

            back_history.push_back(std::move(this->current));
            this->current = std::move(this->forward_history.back());
            this->forward_history.pop_back();
        }

        return this->current;
    }
};

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory* obj = new BrowserHistory(homepage);
 * obj->visit(url);
 * string param_2 = obj->back(steps);
 * string param_3 = obj->forward(steps);
 */