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
        var maxHeap = new PriorityQueue<int, int>(nums.Length);
        foreach ((int num, int frequency) in frequencies)
        {
            maxHeap.Enqueue(element: num, priority: -frequency);
        }

        int[] results = new int[k];
        for (int i = 0; i < k; i++)
        {
            results[i] = maxHeap.Dequeue();
        }

        return results;
    }
}
