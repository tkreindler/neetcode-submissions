/**
 * Definition of Interval:
 * public class Interval {
 *     public int start, end;
 *     public Interval(int start, int end) {
 *         this.start = start;
 *         this.end = end;
 *     }
 * }
 */

public class Solution {
    public bool CanAttendMeetings(List<Interval> intervals)
    {
        intervals.Sort((lhs, rhs) => lhs.start.CompareTo(rhs.start));

        for (int i = 1; i < intervals.Count; i++)
        {
            Interval previousInterval = intervals[i - 1];
            Interval currentInterval = intervals[i];

            if (currentInterval.start < previousInterval.end)
            {
                return false;
            }
        }

        return true;
    }
}
