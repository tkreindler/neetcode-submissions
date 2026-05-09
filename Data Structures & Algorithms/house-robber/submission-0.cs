public class Solution
{
    public int Rob(int[] nums)
    {
        int?[] cache = new int?[nums.Length];
        return this.Helper(houses: nums, startIndex: 0, cache: cache);
    }

    private int Helper(IReadOnlyList<int> houses, int startIndex, int?[] cache)
    {
        if (startIndex >= houses.Count)
        {
            return 0;
        }

        int? cachedValue = cache[startIndex];
        if (cachedValue is not null)
        {
            return cachedValue.Value;
        }

        int takeValue = houses[startIndex] + this.Helper(houses, startIndex + 2, cache);
        int skipValue = this.Helper(houses, startIndex + 1, cache);

        int result = Math.Max(takeValue, skipValue);

        cache[startIndex] = result;
        return result;
    }
}
