public class Solution
{
    public int NumDistinct(string s, string t)
    {
        // dynamic cache, index cache[sIndex][tIndex];
        int?[][]cache = new int?[s.Length][];
        for (int i = 0; i < s.Length; i++)
        {
            cache[i] = new int?[t.Length];
        }

        return this.RecursiveDP(s, 0, t, 0, cache);
    }

    private int RecursiveDP(string s, int sIndex, string t, int tIndex, int?[][]cache)
    {
        // if t is empty we got a match implicitly, all letters in s (if any exist) can just be dropped
        if (tIndex == t.Length)
        {
            return 1;
        }

        // out of subsequences, t is non-empty, there are no valid matches
        if (sIndex == s.Length)
        {
            return 0;
        }

        int? cachedValue = cache[sIndex][tIndex];
        if (cachedValue.HasValue)
        {
            return cachedValue.Value;
        }

        int numMatches = 0;

        if (s[sIndex] == t[tIndex])
        {
            // only if the letters match, we have the option to "take" t[0] by using s[0]
            numMatches += this.RecursiveDP(s, sIndex + 1, t, tIndex + 1, cache);
        }

        // whether the letters match or not, we always have the option to skip s[0]
        numMatches += this.RecursiveDP(s, sIndex + 1, t, tIndex, cache);
        
        cache[sIndex][tIndex] = numMatches;
        return numMatches;
    }

    private int RecursiveBruteForce(ReadOnlySpan<char> s, ReadOnlySpan<char> t)
    {
        // if t is empty we got a match implicitly, all letters in s (if any exist) can just be dropped
        if (t.Length == 0)
        {
            return 1;
        }

        // out of subsequences, t is non-empty, there are no valid matches
        if (s.Length == 0)
        {
            return 0;
        }

        int numMatches = 0;

        if (s[0] == t[0])
        {
            // only if the letters match, we have the option to "take" t[0] by using s[0]
            numMatches += this.RecursiveBruteForce(s[1..], t[1..]);
        }

        // whether the letters match or not, we always have the option to skip s[0]
        numMatches += this.RecursiveBruteForce(s[1..], t);
        
        return numMatches;
    }
}