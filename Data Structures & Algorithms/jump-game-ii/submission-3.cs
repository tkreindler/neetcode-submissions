public class Solution {
    public int Jump(int[] nums)
    {
        return this.Helper(nums);
    }

    private int Helper(IReadOnlyList<int> nums)
    {
        int?[] minHopsArray = new int?[nums.Count];

        // set the end of the array to simplify the array logic - it's value is ignored anyways
        minHopsArray[nums.Count - 1] = 0;

        for (int i = nums.Count - 2; i >= 0; i--)
        {
            int? minHops = null;

            int numAvailableHops = nums[i];
            for (int j = 1; j <= numAvailableHops; j++)
            {
                if (i + j >= minHopsArray.Length - 1)
                {
                    // got to the end, optimized early return
                    minHops = 1;
                    break;
                }

                int? foundMinHops = minHopsArray[i + j];
                if (foundMinHops is null)
                {
                    continue;
                }

                int localMinHops = foundMinHops.Value + 1;
                if (minHops.HasValue)
                {
                    minHops = Math.Min(minHops.Value, localMinHops);
                }
                else
                {
                    minHops = localMinHops;
                }
            }

            minHopsArray[i] = minHops;
        }

        return minHopsArray[0].Value;
    }
}