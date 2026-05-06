public class Solution
{
    private readonly IReadOnlySet<string> validLetterDecodings = Enumerable.Range(1, 26)
        .Select(x => x.ToString())
        .ToHashSet();

    public int NumDecodings(string s)
    {
        var cache = new int?[s.Length];
        return this.Helper(s, 0, cache);
    }

    private int Helper(string s, int startIndex, int?[] cache)
    {
        if (startIndex == s.Length)
        {
            // perfect match
            return 1;
        }
        else if (startIndex > s.Length)
        {
            // extraneous/goes off too far - don't count this branch
            return 0;
        }

        int? cachedValue = cache[startIndex];
        if (cachedValue is not null)
        {
            return cachedValue.Value;
        }

        ReadOnlySpan<char> span = s.AsSpan(startIndex);

        int validDecodings = 0;

        if (this.IsValid(span.Slice(0, 1)))
        {
            validDecodings += this.Helper(s, startIndex + 1, cache);
        }

        if (span.Length > 1 &&
            this.IsValid(span.Slice(0, 2)))
        {
            validDecodings += this.Helper(s, startIndex + 2, cache);
        }

        cache[startIndex] = validDecodings; 
        return validDecodings;
    }

    private bool IsValid(ReadOnlySpan<char> s)
    {
        // Todo use an alternate lookup with spans to avoid an allocation
        return this.validLetterDecodings.Contains(s.ToString());
    }
}
