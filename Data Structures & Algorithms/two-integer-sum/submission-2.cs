public class Solution {
    public int[] TwoSum(int[] nums, int target)
    {
        var set = new Dictionary<int, List<int>>(nums.Length);
        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];

            List<int> list;
            if (!set.TryGetValue(num, out list))
            {
                // TODO optimize to one dictionary lookup with CollectionsMarshall
                list = new List<int>(1);
                set[num] = list;
            }
            
            // add the index
            list.Add(i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            int num = nums[i];
            int difference = target - num;
            if (set.TryGetValue(difference, out List<int> list))
            {
                foreach (int j in list)
                {
                    if (i != j)
                    {
                        return [i, j];
                    }
                }
            }
        }

        throw new NotImplementedException("impossible");
    }
}
