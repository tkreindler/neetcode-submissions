class Logger {

    const int modulus = 10;


    // backward map covers [divider % modulus - modulus, divider % modulus]
    // forward map covers [divider % modulus, divider % modulus + modulus]
    int divider = std::numeric_limits<int>::min();

    unordered_map<string, int> backward_map;
    unordered_map<string, int> forward_map;


public:
    Logger()
    {
        
    }
    
    bool shouldPrintMessage(int timestamp, string message)
    {
        if (timestamp >= divider + modulus * 2)
        {
            // message is FAR in the future, fast forward
            backward_map.clear();
            forward_map.clear();

            // move the forward and backward map ranges up
            divider = timestamp;
        }
        else if (timestamp >= divider + modulus)
        {
            // move forward by one
            backward_map = std::move(forward_map);
            forward_map.clear();
            divider += modulus;
        }

        // check our current dict
        {
            auto iter = forward_map.find(message);

            if (iter != forward_map.end())
            { 
                int found_timestamp = iter->second;
                if (found_timestamp > timestamp - 10)
                {
                    return false;
                }
            }
        }

        // check the backup dict holding the previous 10 seconds
        {
            auto iter = backward_map.find(message);

            if (iter != backward_map.end())
            {
                int found_timestamp = iter->second;
                if (found_timestamp > timestamp - 10)
                {
                    return false;
                }
            }
        }

        // update it for the future in the current dict
        forward_map[message] = timestamp;
        
        return true;
    }
};