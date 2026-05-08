public class Solution
{
    public string LongestPalindrome(string s)
    {
        bool?[][] cache = new bool?[s.Length][];
        for (int i = 0; i < s.Length; i++)
        {
            cache[i] = new bool?[s.Length];
        }

        return this.BruteForce(s, cache).ToString();
    }

    private ReadOnlySpan<char> BruteForce(string s, bool?[][] cache)
    {
        ReadOnlySpan<char> max = [];

        for (int low = 0; low < s.Length; low++)
        {
            for (int high = low + 1; high <= s.Length; high++)
            {
                int newLength = high - low;
                if (newLength <= max.Length)
                {
                    continue;
                }

                if (this.IsPalindrome(s, low, newLength, cache))
                {
                    max = s.AsSpan(low, newLength);
                }
            }
        }

        return max;
    }

    private bool IsPalindrome(string s, int low, int length, bool?[][] cache)
    {
        if (cache[low][length - 1] is bool cachedIsPalindrome)
        {
            return cachedIsPalindrome;
        }

        bool isPalindrome = true;

        ReadOnlySpan<char> segment = s.AsSpan(low, length);
        if (segment[0] != segment[length - 1])
        {
            isPalindrome = false;
        }

        for (int left = 0; left < segment.Length / 2; left++)
        {
            int right = segment.Length - 1 - left;

            if (segment[left] != segment[right])
            {
                isPalindrome = false;
                break;
            }
        }

        cache[low][length - 1] = isPalindrome;
        return isPalindrome;
    }
}
