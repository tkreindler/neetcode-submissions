public class Solution {
    public int[][] Insert(int[][] intervals, int[] newInterval) {
        int newBegin = newInterval[0];
        int newEnd = newInterval[1];
        int insertionStart = this.BinarySearch(intervals.Select(x => x[0]).ToArray(), newBegin);
        int insertionEnd = this.BinarySearch(intervals.Select(x => x[1]).ToArray(), newEnd);

        if (insertionStart > 0 &&
            intervals[insertionStart - 1][1] >= newBegin)
        {
            // Start our new interval at the start of this existing interval
            newBegin = intervals[insertionStart - 1][0];

            // lower the index so we absorb it
            insertionStart -= 1;
        }

        if (insertionEnd < intervals.Length &&
            intervals[insertionEnd][0] <= newEnd)
        {
            // End our new interval at the end of this existing interval
            newEnd = intervals[insertionEnd][1];

            // increase the index so we absorb it
            insertionEnd += 1;
        }

        var precedingSlice = insertionStart > 0 ?
            intervals[0..insertionStart] :
            [];

        var followingSlice = insertionEnd < intervals.Length ?
            intervals[insertionEnd .. intervals.Length] :
            [];
        
        return
        [
            .. precedingSlice,
            [newBegin, newEnd],
            .. followingSlice,
        ];
    }

    private int BinarySearch(int[] values, int desiredValue)
    {
        int low = 0;
        int high = values.Length;

        while (low < high)
        {
            int mid = (high + low) / 2;
            int midValue = values[mid];

            if (desiredValue <= midValue)
            {
                high = mid;
            }
            else
            {
                low = mid + 1;
            }
        }

        return low;
    }
}
