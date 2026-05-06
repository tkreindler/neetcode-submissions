public class Solution {
    public int[][] KClosest(int[][] points, int k)
    {
        // value (first thing) is the point array
        // key (second thing) is the distance squared
        var minHeap = new PriorityQueue<int[], int>(points.Length);
        for (int i = 0; i < points.Length; i++)
        {
            int[] point = points[i];
            int distanceSquared = point[0] * point[0] + point[1] * point[1];

            minHeap.Enqueue(point, distanceSquared);
        }

        int[][] results = new int[k][];

        for (int i = 0; i < k; i ++)
        {
            int[] point = minHeap.Dequeue();
            results[i] = point;
        }

        return results;
    }
}
