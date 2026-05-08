public class Solution
{
    public string LongestPalindrome(string s)
    {
        return this.Helper(s).ToString();
    }

    private ReadOnlySpan<char> Helper(string s)
    {
        bool?[][] cache = new bool?[s.Length][];
        for (int i = 0; i < s.Length; i++)
        {
            cache[i] = new bool?[s.Length];
        }

        ReadOnlySpan<char> max = [];

        for (int low = 0; low < s.Length; low++)
        {
            for (int high = low; high < s.Length; high++)
            {
                int newLength = high - low + 1;
                if (newLength <= max.Length)
                {
                    continue;
                }

                if (this.IsPalindrome(s, low, high, cache))
                {
                    max = s.AsSpan(low, newLength);
                }
            }
        }

        return max;
    }

    private bool IsPalindrome(string s, int low, int high, bool?[][] cache) 
    {
        if (low >= high)
        {
            return true;
        }

        if (cache[low][high] is bool cachedIsPalindrome)
        {
            return cachedIsPalindrome;
        }

        bool isPalindrome = true;

        if (s[low] != s[high])
        {
            isPalindrome = false;
        }
        else
        {
            isPalindrome = this.IsPalindrome(s, low + 1, high - 1, cache);
        }

        cache[low][high] = isPalindrome;
        return isPalindrome;
    }
}
