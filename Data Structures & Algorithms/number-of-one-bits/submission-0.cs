public class Solution {
    public int HammingWeight(uint n)
    {
        long val = (long)n;
        int numOneBits = 0;
        
        while (val > 0)
        {
            int remainder = (int)(val % 2);
            val /= 2;

            numOneBits += remainder;
        }
        
        return numOneBits;
    }
}
