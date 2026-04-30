public class Solution {
    public bool MergeTriplets(int[][] triplets, int[] target) {
        return this.Helper(triplets, target);
    }

    private bool Helper(IReadOnlyList<IReadOnlyList<int>> triplets, IReadOnlyList<int> target)
    {
        for (int i = 0; i < 3; i++)
        {
            bool foundMatch = false;
            foreach (IReadOnlyList<int> triplet in triplets)
            {
                if (IsMatch(triplet, i, target))
                {
                    foundMatch = true;
                }
            }

            if (!foundMatch)
            {
                return false;
            }
        }

        return true;
    }

    private bool IsMatch(IReadOnlyList<int> triplet, int targetIndex, IReadOnlyList<int> target)
    {
        // target index must match, others must be <= (so they can be merged silently)
        if (triplet[targetIndex] != target[targetIndex])
        {
            return false;
        }

        for (int i = 0; i < 3; i++)
        {
            if (triplet[i] > target[i])
            {
                return false;
            }
        }

        return true;
    }
}
