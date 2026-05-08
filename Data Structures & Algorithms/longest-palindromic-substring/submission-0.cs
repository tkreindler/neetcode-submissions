public class Solution
{
    public string LongestPalindrome(string s)
    {
        return this.BruteForce(s).ToString();
    }

    private ReadOnlySpan<char> BruteForce(ReadOnlySpan<char> s)
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

                ReadOnlySpan<char> segment = s.Slice(low, newLength);

                if (this.IsPalindrome(segment))
                {
                    max = segment;
                }
            }
        }

        return max;
    }

    private bool IsPalindrome(ReadOnlySpan<char> segment)
    {
        for (int left = 0; left < segment.Length / 2; left++)
        {
            int right = segment.Length - 1 - left;

            if (segment[left] != segment[right])
            {
                return false;
            }
        }

        return true;
    }
}
