

class BrowserHistory {

    vector<string> history;
    int64_t current;


  public:
    BrowserHistory(string homepage)
    {
        this->history.push_back(homepage);
        this->current = 0;
    }
    
    void visit(string url)
    {
        this->history.erase(this->history.begin() + current + 1, this->history.end());

        this->current += 1;
        this->history.push_back(url);
    }
    
    string back(int steps)
    {
        int64_t zero = 0;
        this->current = std::max(zero, this->current - steps);
        return this->history.at(this->current);
    }
    
    string forward(int steps)
    {
        this->current = std::min((int64_t)this->history.size() - 1, this->current + steps);
        return this->history.at(this->current);
    }
};

/**
 * Your BrowserHistory object will be instantiated and called as such:
 * BrowserHistory* obj = new BrowserHistory(homepage);
 * obj->visit(url);
 * string param_2 = obj->back(steps);
 * string param_3 = obj->forward(steps);
 */