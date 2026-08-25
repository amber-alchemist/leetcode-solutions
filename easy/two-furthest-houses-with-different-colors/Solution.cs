// https://leetcode.com/problems/two-furthest-houses-with-different-colors
// #greedy_algorithm
public class Solution
{
	public int MaxDistance(int[] colors)
	{
		int n = colors.Length;
		for (int i = 0; i < n - 1; ++i) {
			if (colors[0] != colors[n - 1 - i] || colors[n - 1] != colors[i]) {
				return n - 1 - i;
			}
		}
		return -1;
	}
}
