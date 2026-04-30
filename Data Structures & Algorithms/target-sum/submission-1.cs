public class Solution {
    public int FindTargetSumWays(int[] nums, int target)
    {
        // initialize the starting state
        IReadOnlyDictionary<int, int> previousStep = new Dictionary<int, int>
        {
            // The start of the list has only one possibility - sum of 0
            { 0, 1 },
        };

        foreach (int num in nums)
        {
            var newStep = new Dictionary<int, int>(previousStep.Count * 2);

            foreach ((int previousSum, int previousWays) in previousStep)
            {
                // Add
                {
                    int newSum = previousSum + num;
                    ref int newWaysRef = ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(newStep, newSum, out _);
                    newWaysRef += previousWays;
                }
                // Subtract
                {
                    int newSum = previousSum - num;
                    ref int newWaysRef = ref System.Runtime.InteropServices.CollectionsMarshal.GetValueRefOrAddDefault(newStep, newSum, out _);
                    newWaysRef += previousWays;
                }
            }

            previousStep = newStep;
        }

        if (previousStep.TryGetValue(target, out int ways))
        {
            return ways;
        }
        else
        {
            return 0;
        }
    }
}
