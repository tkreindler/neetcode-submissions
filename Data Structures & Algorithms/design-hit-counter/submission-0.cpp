class HitCounter {
    deque<int> timestamps;

    void update(int timestamp)
    {
        // erase all timestamps lower than timestamp
        auto iter = std::upper_bound(this->timestamps.begin(), this->timestamps.end(), timestamp - 300);

        this->timestamps.erase(this->timestamps.begin(), iter);
    }

public:
    HitCounter() {
        
    }
    
    void hit(int timestamp)
    {
        this->timestamps.push_back(timestamp);
        this->update(timestamp);
    }
    
    int getHits(int timestamp)
    {
        this->update(timestamp);
        return this->timestamps.size();
    }
};

/**
 * Your HitCounter object will be instantiated and called as such:
 * HitCounter* obj = new HitCounter();
 * obj->hit(timestamp);
 * int param_2 = obj->getHits(timestamp);
 */
