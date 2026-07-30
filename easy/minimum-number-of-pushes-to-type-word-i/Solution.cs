// https://leetcode.com/problems/minimum-number-of-pushes-to-type-word-i
// #greedy_algorithm
public class Solution
{
	public int MinimumPushes(string word)
	{
		int minimumPushesCount = 0;
		int setsCount = Math.DivRem(word.Length, 8, out int remainPushes);
		int pushesPerLetter = 1;
		for (; pushesPerLetter <= setsCount; ++pushesPerLetter) {
			minimumPushesCount += 8 * pushesPerLetter;
		}
		minimumPushesCount += remainPushes * pushesPerLetter;
		return minimumPushesCount;
	}
}
