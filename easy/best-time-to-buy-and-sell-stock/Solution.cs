// https://leetcode.com/problems/best-time-to-buy-and-sell-stock
// #dynamic_programming
public class Solution
{
	public int MaxProfit(int[] prices)
	{
		int maxProfit = 0;
		int sellPrice = prices[^1];
		for (int i = prices.Length - 2; i >= 0; --i) {
			if (prices[i + 1] > sellPrice) {
				sellPrice = prices[i + 1];
			}
			if (prices[i] < sellPrice) {
				maxProfit = Math.Max(maxProfit, sellPrice - prices[i]);
			}
		}
		return maxProfit;
	}
}
