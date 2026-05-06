public class Solution
{
    private readonly IReadOnlyDictionary<char, char> inverse = new Dictionary<char, char>
    {
        { '(', ')' },
        { '[', ']' },
        { '{', '}' },
    };

    private readonly IReadOnlyDictionary<char, bool> isOpening = new Dictionary<char, bool>
    {
        { '(', true },
        { '{', true },
        { '[', true },

        { ')', false },
        { '}', false },
        { ']', false },
    };

    public bool IsValid(string s)
    {
        var currentOpenParentheses = new Stack<char>();

        foreach (char letter in s)
        {
            if (this.isOpening[letter])
            {
                currentOpenParentheses.Push(letter);
            }
            else
            {
                if (currentOpenParentheses.Count == 0)
                {
                    // none open, fail
                    return false;
                }

                char openParenthesis = currentOpenParentheses.Pop();
                if (letter != this.inverse[openParenthesis])
                {
                    // mismatch, fail
                    return false;
                }
            }
        }

        return currentOpenParentheses.Count == 0;
    }
}
