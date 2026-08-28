// https://leetcode.com/problems/koko-eating-bananas
// #binary_search
public class Solution
{
	public int MinEatingSpeed(int[] piles, int h)
	{
		int maxPileSize = piles[0];
		for (int i = 1; i < piles.Length; ++i) {
			maxPileSize = Math.Max(maxPileSize, piles[i]);
		}

		int slowestSpeed = 1, fastestSpeed = maxPileSize;
		while (slowestSpeed < fastestSpeed) {
			int checkedSpeed = (slowestSpeed + fastestSpeed) >> 1;
			int spendedHours = 0;
			for (int i = 0; i < piles.Length; ++i) {
				spendedHours += Math.DivRem(piles[i], checkedSpeed, out int remainder);
				if (remainder > 0) {
					++spendedHours;
				}
				if (spendedHours > h) {
					break;
				}
			}
			if (spendedHours > h) {
				slowestSpeed = checkedSpeed + 1;
			}
			else {
				fastestSpeed = checkedSpeed;
			}
		}
		return fastestSpeed;
	}
}
