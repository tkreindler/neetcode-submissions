class Solution {
public:
    vector<vector<int>> combinationSum(const vector<int>& nums, int target)
    {
        return this->helper(nums.begin(), nums.end(), target);
    }

    vector<vector<int>> helper(
        vector<int>::const_iterator nums_begin,
        vector<int>::const_iterator nums_end,
        int workingTarget)
    {
        if (workingTarget == 0)
        {
            return {{}};
        }

        if (workingTarget < 0)
        {
            return {};
        }

        vector<vector<int>> results;
        for (auto iter = nums_begin; iter != nums_end; ++iter)
        {
            int num = *iter;
            vector<vector<int>> branchResults = this->helper(iter, nums_end, workingTarget - num);
            for (vector<int>& result : branchResults)
            {
                result.push_back(num);
                results.push_back(result);
            }
        }

        return results;
    }
};
