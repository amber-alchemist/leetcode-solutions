// https://leetcode.com/problems/stone-game
// #game_theory #two_pointers
public class Solution
{
	public bool StoneGame(int[] piles)
	{
		int aliceScore = 0, bobScore = 0;
		int begin = 0, end = piles.Length - 1;
		while (begin < end) {
			if (piles[begin] == piles[end]) {
				if (begin - end == 1) {
					aliceScore += piles[begin++];
					bobScore += piles[end--];
				} else {
					if (piles[begin + 1] > piles[end - 1]) {
						aliceScore += piles[end--];
						bobScore += piles[begin++];
					} else {
						aliceScore += piles[begin++];
						bobScore += piles[end--];
					}
				}
			} else {
				if (piles[begin] > piles[end]) {
					aliceScore += piles[begin++];
					bobScore += piles[end--];
				} else {
					aliceScore += piles[end--];
					bobScore += piles[begin++];
				}
			}
		}
		return aliceScore > bobScore;
	}
}
