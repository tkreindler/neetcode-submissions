public class Solution {
    public bool CheckValidString(string s)
    {
        int minOpenCount = 0;
        int maxOpenCount = 0;

        foreach (char letter in s)
        {
            switch (letter)
            {
                case '(':
                    minOpenCount += 1;
                    maxOpenCount += 1;
                    break;

                case ')':
                    minOpenCount -= 1;
                    maxOpenCount -= 1;

                    // too many closed, not possible to be valid, early return
                    if (maxOpenCount < 0)
                    {
                        return false;
                    }

                    break;

                case '*':
                    minOpenCount -= 1;
                    maxOpenCount += 1;
                    break;

                default:
                    throw new NotImplementedException($"Unexpected letter '{letter}'");
            }

            // can never go below 0 open at a time
            if (minOpenCount < 0)
            {
                minOpenCount = 0;
            }
        }
        
        return maxOpenCount >= 0 && minOpenCount <= 0;
    }
}
