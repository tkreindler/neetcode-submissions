public class Solution {
    public int MaxProfit(int[] prices)
    {
        return this.Helper(prices);
    }

    private int Helper(IReadOnlyList<int> prices)
    {
        int maxProfit = 0;
        int previousMinPrice = prices[0];

        for (int i = 1; i < prices.Count; i++)
        {
            int todayPrice = prices[i];
            int newProfit = todayPrice - previousMinPrice;
            maxProfit = Math.Max(maxProfit, newProfit);

            previousMinPrice = Math.Min(todayPrice, previousMinPrice);
        }

        return maxProfit;
    }
}
