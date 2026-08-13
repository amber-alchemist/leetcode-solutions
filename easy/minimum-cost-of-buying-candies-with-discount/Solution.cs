// https://leetcode.com/problems/minimum-cost-of-buying-candies-with-discount
// #sorting #greedy_algorithm
public class Solution
{
	public int MinimumCost(int[] cost)
	{
		Array.Sort(cost);
		int minimumCost = 0;
		for (int i = 1; i <= cost.Length; ++i) {
			if (i % 3 > 0) {
				minimumCost += cost[cost.Length - i];
			}
		}
		return minimumCost;
	}
}
