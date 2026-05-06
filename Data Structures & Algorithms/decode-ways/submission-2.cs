public class Solution
{
    private readonly IReadOnlySet<string> validLetterDecodings = Enumerable.Range(1, 26)
        .Select(x => x.ToString())
        .ToHashSet();

    public int NumDecodings(string s)
    {
        // start with the second to last letter for a simple base case
        // check if the last letter is valid on its own
        // two ahead is the end of the word which is always valid
        int validDecodingsAheadOne = this.IsValid(s.AsSpan(s.Length - 1)) ? 1 : 0;
        int validDecodingsAheadTwo = 1;

        for (int i = s.Length - 2; i >= 0; i--)
        {
            int validDecodings = 0;
            if (this.IsValid(s.AsSpan(i, 2)))
            {
                validDecodings += validDecodingsAheadTwo;
            }

            if (this.IsValid(s.AsSpan(i, 1)))
            {
                validDecodings += validDecodingsAheadOne;
            }

            validDecodingsAheadTwo = validDecodingsAheadOne;
            validDecodingsAheadOne = validDecodings;
        }

        return validDecodingsAheadOne;
    }

    private bool IsValid(ReadOnlySpan<char> s)
    {
        // Todo use an alternate lookup with spans to avoid an allocation
        return this.validLetterDecodings.Contains(s.ToString());
    }
}
