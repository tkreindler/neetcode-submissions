public class Solution {
    public int NetworkDelayTime(int[][] times, int n, int k)
    {
        // populate lookup dictionary for edges
        var timeLookups = new Dictionary<int, List<(int destination, int cost)>>(times.Length);
        foreach (int[] time in times)
        {
            int source = time[0];
            int destination = time[1];
            int cost = time[2];

            if (!timeLookups.TryGetValue(source, out List<(int destination, int cost)> list))
            {
                list = new List<(int destination, int cost)>();
                timeLookups[source] = list;
            }

            list.Add((destination, cost));
        }

        // Use a stack for depth-first-search
        var minHeap = new PriorityQueue<int, int>(n);

        // start with k
        minHeap.Enqueue(k, 0);

        // prevent infinite looping from a cycle
        // also map node -> lowest seen total cost for this node
        var visitedCosts = new Dictionary<int, int>(n);

        while (minHeap.Count > 0)
        {
            minHeap.TryDequeue(out int node, out int currentCost);

            // check for multiple ways to get to this node
            if (visitedCosts.TryGetValue(node, out int previousLowestCost))
            {
                if (currentCost >= previousLowestCost)
                {
                    // sub-optimal, skip this to avoid extra work, and more
                    // importantly, to prevent infinite looping on cycles
                    continue;
                }
            }

            visitedCosts[node] = currentCost;

            if (timeLookups.TryGetValue(node, out List<(int destination, int cost)> connections))
            {
                foreach ((int destination, int cost) in connections)
                {
                    minHeap.Enqueue(destination, currentCost + cost);
                }
            }
        }

        if (visitedCosts.Count != n)
        {
            // not all nodes visitable
            return -1;
        }

        // minimum time to visit ALL nodes is the maximum time to visit ONE node
        return visitedCosts.Values.Aggregate(Math.Max);
    }
}
