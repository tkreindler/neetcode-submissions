class Solution {
public:
    bool hasDuplicate(vector<int>& nums)
    {
        std::unordered_set<int> numSet;
        numSet.reserve(nums.size());

        for (int num : nums)
        {
            auto [it, inserted] = numSet.insert(num);
            if (!inserted)
            {
                return true;
            }
        }
        
        return false;
    }
};