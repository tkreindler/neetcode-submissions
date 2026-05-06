public class Solution {
    public int Jump(int[] nums)
    {
        return this.Helper(nums);
    }

    private int Helper(IReadOnlyList<int> nums)
    {
        int maxDistance = 0;
        for (int numHops = 0; ; numHops++)
        {
            // the max distance for the next round - after we've done another hop
            int nextMaxDistance = maxDistance;

            for (int i = 0; i <= maxDistance; i++)
            {
                if (i >= nums.Count - 1)
                {
                    return numHops;
                }
                
                int localMaxDistance = nums[i] + i;
                nextMaxDistance = Math.Max(nextMaxDistance, localMaxDistance);
            }

            maxDistance = nextMaxDistance;
        }

        throw new NotImplementedException("not hit");
    }
}