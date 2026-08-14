// https://leetcode.com/problems/maximize-active-section-with-trade-i
// #greedy_algorithm
public class Solution
{
	public int MaxActiveSectionsAfterTrade(string s)
	{
		int totalActiveSectionsCount = 0;
		int bestTradeValue = 0;
		int previousInactiveBlockSize = 0;
		for (int i = 0; i < s.Length;) {
			for (; i < s.Length && s[i] == '1'; ++i) {
				++totalActiveSectionsCount;
			}

			int currentInactiveBlockSize = 0;
			for (; i < s.Length && s[i] == '0'; ++i) {
				++currentInactiveBlockSize;
			}

			if (previousInactiveBlockSize > 0 && currentInactiveBlockSize > 0) {
				int currentTradeValue = previousInactiveBlockSize + currentInactiveBlockSize;
				bestTradeValue = Math.Max(bestTradeValue, currentTradeValue);
			}
			previousInactiveBlockSize = currentInactiveBlockSize;
		}
		return totalActiveSectionsCount + bestTradeValue;
	}
}
