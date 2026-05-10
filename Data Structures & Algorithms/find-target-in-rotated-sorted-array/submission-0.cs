public class Solution {
    public int Search(int[] nums, int target)
    {
        int lastValue = nums[nums.Length-1];
        int firstValue = nums[0];

        // special case for no rotation
        if (lastValue >= firstValue)
        {
            return this.BinarySearch(nums, target);
        }

        // first find the rotation number, this will be the only index that is descending
        // this is a special sort of binary search where our goal is to set low to the last
        // number which is greater than firstValue, and high to the first number which is
        // less than firstValue, thereby finding the rotation point
        int low = 0;
        int high = nums.Length - 1;
        while (high > low + 1)
        {
            int mid = low + (high - low) / 2;

            int val = nums[mid];

            if (val >= firstValue)
            {
                // mid is before the rotation point
                low = mid;
            }
            else
            {
                // mid is after the rotation point
                high = mid;
            }
        }

        if (target >= firstValue)
        {
            // search the before-rotation segment
            ReadOnlySpan<int> segment = nums.AsSpan(0, high);
            int segmentIndex = this.BinarySearch(segment, target);
            return segmentIndex;
        }
        else
        {
            // search the after-rotation segment
            ReadOnlySpan<int> segment = nums.AsSpan(high);
            int segmentIndex = this.BinarySearch(segment, target);
            return (segmentIndex == -1) ? -1 : segmentIndex + high;
        }
    }

    private int BinarySearch(ReadOnlySpan<int> segment, int target)
    {
        int low = 0;
        int high = segment.Length - 1;
        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            int val = segment[mid];

            if (val == target)
            {
                return mid;
            }
            else if (val < target)
            {
                low = mid + 1;
            }
            else
            {
                high = mid - 1;
            }
        }

        return -1;
    }
}