public class Solution {
    public List<List<int>> Permute(int[] nums)
    {
        var results = new List<List<int>>((int)Math.Pow(2, nums.Length));
        this.Helper(nums, 0, results);
        return results;
    }

    private void Helper(int[] nums, int startIndex, List<List<int>> results)
    {
        if (startIndex == nums.Length)
        {
            results.Add(nums.ToList());
        }

        for (int i = startIndex; i < nums.Length; i++) {
            this.Swap(nums, startIndex, i);
            this.Helper(nums, startIndex + 1, results);
            this.Swap(nums, startIndex, i);
        }
    }

    private void Swap(int[] nums, int l, int r)
    {
        (nums[l], nums[r]) = (nums[r], nums[l]);
    }
}
