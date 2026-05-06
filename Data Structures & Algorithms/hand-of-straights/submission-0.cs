public class Solution {
    public bool IsNStraightHand(int[] hand, int groupSize)
    {
        return this.Helper(hand, groupSize);
    }

    private bool Helper(IReadOnlyList<int> hand, int groupSize)
    {
        // hand can't be evenly divided like that
        if (hand.Count % groupSize != 0)
        {
            return false;
        }

        int numGroups = hand.Count / groupSize;

        var frequenciesDictionary = new Dictionary<int, int>(hand.Count);
        foreach (int card in hand)
        {
            // TODO optimization use CollectionsMarshal for a single-lookup solution
            int previousCount;
            if (!frequenciesDictionary.TryGetValue(card, out previousCount))
            {
                previousCount = 0;
            }

            frequenciesDictionary[card] = previousCount + 1;
        }

        var sortedCards = new List<int>(hand);
        sortedCards.Sort();

        foreach (int card in sortedCards)
        {
            if (frequenciesDictionary[card] == 0)
            {
                // we've already used all of this card, move on to the next one
                continue;
            }

            // loop through the rest of the cards in the group which must exist
            for (int i = 0; i < groupSize; i++)
            {
                int workingCard = card + i;
                if (!frequenciesDictionary.TryGetValue(workingCard, out int count))
                {
                    // card doesn't exist
                    return false;
                }

                if (count == 0)
                {
                    // card has already been exhausted
                    return false;
                }

                frequenciesDictionary[workingCard] = count - 1;
            }
        }

        return true;
    }
}
