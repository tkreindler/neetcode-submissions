public class Solution
{
    public int MaxArea(int[] heights)
    {
        return this.TwoPointers(heights);
    }

    private int TwoPointers(IReadOnlyList<int> heights)
    {
        int max = 0;

        int left = 0;
        int right = heights.Count - 1;

        while (right > left)
        {
            int leftHeight = heights[left];
            int rightHeight = heights[right];

            int boxHeight = Math.Min(leftHeight, rightHeight);

            int boxWidth = right - left;

            int boxArea = boxHeight * boxWidth;

            if (boxArea > max)
            {
                max = boxArea;
            }

            // try moving in the shorter bar
            if (leftHeight < rightHeight)
            {
                left += 1;
            }
            else
            {
                right -= 1;
            }
        }

        return max;
    }

    private int Bruteforce(IReadOnlyList<int> heights)
    {
        int max = 0;

        for (int left = 0; left < heights.Count; left++)
        {
            int leftHeight = heights[left];

            // put a constraint on the left bar, it has to be bigger than some threshold
            // that threshold ensure the bar is high enough and there's enough potential width
            // left that it could possibly make a box greater than max
            if (leftHeight < max / (heights.Count - left))
            {
                continue;
            }

            // start our right bar search from the right hand side so we search the widest boxes first. 

            // can ignore right == left as that box would have a width (and therefore area) of zero
            // can ignore right < left as that would be double counting and inefficient
            for (int right = heights.Count - 1; right > left; right--)
            {
                int rightHeight = heights[right];

                int boxHeight = Math.Min(leftHeight, rightHeight);

                int boxWidth = right - left;

                int boxArea = boxHeight * boxWidth;

                if (boxArea > max)
                {
                    max = boxArea;
                }

                if (rightHeight >= leftHeight)
                {
                    // If we hit a bar >= left height break out early as the left height is now
                    // constraining the height of the box and we already started with the widest boxes
                    break;
                }
            }
        }

        return max;
    }
}
