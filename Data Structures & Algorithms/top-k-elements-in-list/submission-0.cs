public class Solution
{
    public int[] TopKFrequent(int[] nums, int k)
    {
        var frequencies = new Dictionary<int, int>(nums.Length);
        foreach (int num in nums)
        {
            // TODO do single-lookup optimization with CollectionsMarshall
            if (!frequencies.TryGetValue(num, out int frequency))
            {
                frequency = 0;
            }

            frequencies[num] = frequency + 1;
        }

        // TODO: change this to a max heap with a custom comparator, for now use negatives
        var list = new List<(int num, int frequency)>(nums.Length);
        foreach ((int num, int frequency) in frequencies)
        {
            list.Add((num: num, frequency: frequency));
        }

        list.Sort((left, right) => right.frequency.CompareTo(left.frequency));

        return list.Take(k).Select(tup => tup.num).ToArray();
    }
}
