public class Solution {
    public List<List<int>> ThreeSum(int[] nums)
    {
        Array.Sort(nums);
        var lookup = new Dictionary<int, List<int>>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            if (!lookup.TryGetValue(num, out List<int> set))
            {
                set = new List<int>(2);
                lookup[num] = set;
            }

            // store the index for each number
            set.Add(i);
        }

        var results = new List<List<int>>();

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1]) continue;
            // start higher than i to ensure no duplicates
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue;
                int complement = -1 * (nums[i] + nums[j]);
                if (!lookup.TryGetValue(complement, out List<int> list))
                {
                    // none exist
                    continue;
                }

                foreach (int k in list)
                {
                    // make sure it's higher than j to ensure no duplicates
                    if (k > j)
                    {
                        results.Add([nums[i], nums[j], nums[k]]);
                        break;
                    }
                }

            }
        }

        return results;
    }
}