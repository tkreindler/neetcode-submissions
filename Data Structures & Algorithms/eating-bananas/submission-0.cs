public class Solution {
    public int MinEatingSpeed(int[] piles, int h)
    {
        int maxHeight = 0;
        for (int i = 0; i < piles.Length; i++)
        {
            int height = piles[i];
            if (height > maxHeight) maxHeight = height;
        }

        // TODO handle k=0 edge case?

        int low = 1;
        int high = maxHeight;
        while (low < high)
        {
            int mid = low + (high - low) / 2;
            long totalTurns = 0;
            for (int i = 0; i < piles.Length; i++)
            {
                int height = piles[i];
                double quotient = ((double)height) / mid;
                int turns = (int)Math.Ceiling(quotient);

                totalTurns += turns;
            }

            if (totalTurns > h)
            {
                low = mid + 1;
            }
            else
            {
                high = mid;
            }
        }

        return low;
    }
}